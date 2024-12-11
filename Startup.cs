using Azure.Storage.Blobs;
using Azure.Storage;


namespace AzureStorage.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var key = Environment.GetEnvironmentVariable("Key"); 
            var accountName = Environment.GetEnvironmentVariable("AccountName");

            var blobServiceClient = new BlobServiceClient(new Uri($"https://{accountName}.blob.core.windows.net"), new StorageSharedKeyCredential(accountName, key));

            services.AddSingleton<BlobServiceClient>(blobServiceClient);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
