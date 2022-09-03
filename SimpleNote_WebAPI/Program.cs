

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//config for JWT Bearer

//var jwtTokenConfig = builder.Configuration.GetSection("JWT").Get<JwtTokenConfig>();
//builder.Services.AddSingleton<JwtTokenConfig>(jwtTokenConfig);
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = true;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidIssuer = jwtTokenConfig.Issuer,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.key)),
//        ValidAudience = jwtTokenConfig.Audience,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.FromMinutes(1)
//    };
//});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, //private key
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

        };
    });

//DB Connection Service

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Services config

//builder.Services.AddIdentity<UsersEntity, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepoImp<>));

builder.Services.AddTransient<INotesRepo, NotesRepoImp>();
builder.Services.AddTransient<IProjectsRepo, ProjectsRepoImp>();
builder.Services.AddTransient<IAttributiesRepo, AttributiesRepoImp>();

builder.Services.AddTransient<INotesServices, NotesServicesImp>();
builder.Services.AddTransient<IProjectsServices, ProjectsServicesImp>();
builder.Services.AddTransient<ISecurityServices, SecurityServicesImp>();
builder.Services.AddTransient<IAttributiesServices, AttributiesServicesImp>();

builder.Services.AddTransient(typeof(IGenericServices<,>), typeof(GenericServicesImp<,>));

//AutoMapper
builder.Services.AddAutoMapper(options => options.AddProfile<AttributiesProfile>());
builder.Services.AddAutoMapper(options => options.AddProfile<NotesProfile>());
builder.Services.AddAutoMapper(options => options.AddProfile<UsersProfile>());
builder.Services.AddAutoMapper(options => options.AddProfile<ProjectsProfile>());

//CORS Services
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//add use cors
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
