follow tutorial:
	https://www.youtube.com/watch?v=LVYEqNkf3aI

Step 1:
	Create .Net Core Web App named "IdentityServer"

Step 2:
	Add nuget packages as:
		=> IdentityServer4 3.1.2
		=> IdentityServer4.EntityFramework 3.1.2

Step 3:
	Add Config.css class in proj
	=> Create GetApiResource method
	=> then create GetClient method
	note: you set 4 values care fully  
		=> client_id = "secret_client_id"
		=> grant_type = "client_credentials"
		=> scope = "apiscope"
		=> client_secret = "secret"


step 4: 
	add service in Configure method of Startup class with 
				services.AddIdentityServer().
                AddDeveloperSigningCredential()
                .AddOperationalStore(option =>
                {
                    option.EnableTokenCleanup = true;
                    option.TokenCleanupInterval = 30; // in seconds
                })
                .AddInMemoryApiResources(Config.GetApiRescources())
                .AddInMemoryClients(Config.GetClients());
step 5: 
	Add medleware in ConfigureService Method
		            app.UseIdentityServer();

step 6:
	Create second prject with .net core api api
	

step 7:
	install nuget pkg
		=> jwtbearer package	3.1.1

step 8: 
	add services 
			services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:44311";
                o.Audience = "myresourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PublicSecure", pollicy => PolicyHandler.AuthorizeRequest(pollicy));
            });

step 9:
	add meddleware
		app.UseAuthentication();
            app.UseAuthorization();

step 9:
	add authorize filter with policy descibe in service as
		  =>       [Authorize(Policy = "PublicSecure")]

run both project and get jwt token from identiry server 
then by passing token in request try to get data from microserive