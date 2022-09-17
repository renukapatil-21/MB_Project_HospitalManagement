using Application.Data.DataAccess;
using Application.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataAccess<Patient, int>, PatientDataAccess>();
builder.Services.AddScoped<IDataAccess<Doctor, int>, DoctorDataAccess>();
builder.Services.AddScoped<IDataAccess<Hospital_Setting, int>, HospitalSettingDataAccess>();
builder.Services.AddScoped<IDataAccess<Nurse, int>, NurseDataAccess>();
builder.Services.AddScoped<IDataAccess<Other_Services, int>, OtherServicesDataAccess>();
builder.Services.AddScoped<IDataAccess<Doctor_Patient_Visit, int>, DoctorPatientVisitDataAccess>();

builder.Services.AddScoped<IDataAccess<Patient_Medicine, int>, PatientMedicineDataAccess>();
builder.Services.AddScoped<IDataAccess<Patient_Room, int>, PatientRoomDataAccess>();
builder.Services.AddScoped<IDataAccess<Room, int>, RoomDataAccess>();
builder.Services.AddScoped<IDataAccess<Wardboy, int>, WardboyDataAccess>();
builder.Services.AddScoped<IDataAccess<Ward, int>, WardDataAccess>();




builder.Services.AddScoped<IServiceRepository<Patient, int>, PatientRepository>();
builder.Services.AddScoped<IServiceRepository<Doctor, int>, DoctorRepository>();
builder.Services.AddScoped<IServiceRepository<Nurse, int>, NurseRepository>();
builder.Services.AddScoped<IServiceRepository<Hospital_Setting, int>, HospitalSettingRepository>();
builder.Services.AddScoped<IServiceRepository<Doctor_Patient_Visit, int>, DoctorPatientVisitRepository>();
builder.Services.AddScoped<IServiceRepository<Other_Services, int>, OtherServicesRepository>();

builder.Services.AddScoped<IServiceRepository<Patient_Medicine, int>, PatientMedicineRepository>();
builder.Services.AddScoped<IServiceRepository<Patient_Room, int>, PatientRoomRepository>();
builder.Services.AddScoped<IServiceRepository<Room, int>, RoomRepository>();
builder.Services.AddScoped<IServiceRepository<Wardboy, int>, WardboyRepository>();
builder.Services.AddScoped<IServiceRepository<Ward, int>, WardRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
