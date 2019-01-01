using FullShelves.Repository;
using FullShelves.Repository.Contract;
using FullShelves.Service;
using FullShelves.Service.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FullShelves.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      #region Services

      services.AddTransient<IGenreService, GenreService>();
      services.AddTransient<IAuthorService, AuthorService>();

      #endregion

      #region Repository

      services.AddSingleton(Configuration);

      services.AddTransient<IConnection, Connection>();
      services.AddTransient<IGenreRepository, GenreRepository>();
      services.AddTransient<IAuthorRepository, AuthorRepository>();

      #endregion

      services.AddMvc();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Version = "v1",
          Title = "Full Shelves",
          Description = "powered by Microsoft Azure =)",
          TermsOfService = "None",
          Contact = new Contact
          {
            Name = "Kenely de Oliveira",
            Email = "kenely.oliveira@gmail.com",
            Url = "https://github.com/KenelyOliveira"
          },
        });
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Full Shelves v1");
      });

      app.UseMvc();
    }
  }
}
