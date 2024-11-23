using SipaksiNew.Api.Extensions;
using SipaksiNew.Common.Application;
using SipaksiNew.Common.Infrastructure;
using SipaksiNew.Modules.User.Infrastructure;
using System.Drawing.Printing;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services
    .AddEntityFrameworkMySQL()
    .AddDbContext<DBContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    });*/

//builder.Services.AddControllers();
//builder.Services.AddUserModule(builder.Configuration);

builder.Configuration.AddModuleConfiguration(["User"]);
builder.Services.AddApplication([SipaksiNew.Modules.User.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);
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
