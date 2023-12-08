using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace YukiTest.API.Configuration
{
    public static class YukiAPIConfiguration
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {

                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json", "application/xml"));

            }).AddJsonOptions(options =>
            {
                // If you like nulls or not...
                //options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.AddEndpointsApiExplorer();

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny",
                    builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            );
            });

            RepositoryRegistration(services);


            services.AddSwaggerGen(options =>
            {
                
                string searchPattern = "*.xml";
                List<string> allMyXmlCommentFileNames = Directory.GetFiles(AppContext.BaseDirectory, searchPattern, SearchOption.AllDirectories).ToList();
                foreach (string xmlFilePath in allMyXmlCommentFileNames)
                {
                    options.IncludeXmlComments(xmlFilePath, includeControllerXmlComments: true);
                }
                options.OrderActionsBy((apiDesc) => apiDesc.RelativePath);
            });

            return services;
        }

        private static void RepositoryRegistration(IServiceCollection services)
        {
            IList<Assembly> assemblies = new List<Assembly>();
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
            var filesFiltered = files.Where(x => x.Split("\\").Last().Contains("YukiTest.")).ToList();
            foreach (string assemblyPath in filesFiltered)
            {
                var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                assemblies.Add(assembly);
            }
            //.. register
            foreach (var assembly in assemblies)
            {
                assembly
                .GetTypes()
                .Where(a => a.Name.EndsWith("Repository") && !a.IsAbstract && !a.IsInterface)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });
            }
        }



    }
}
