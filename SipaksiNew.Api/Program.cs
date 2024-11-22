using SipaksiNew.User;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services
    .AddEntityFrameworkMySQL()
    .AddDbContext<DBContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    });*/

//builder.Services.AddControllers();
builder.Services.AddUserModule(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();
UserModule.MapEndpoints(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
