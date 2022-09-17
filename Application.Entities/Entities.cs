using Application.Entities.Base;

namespace Application.Entities
{
    public class Patient : Entity
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
    }

    public class Doctor : Entity
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Specialisation { get; set; }
        public string DoctorType { get; set; }
        public string Gender { get; set; }
    }

    public class Hospital_Setting : Entity
    {
        public int HospitalSettingID { get; set; }
        public string HospitalSettingName { get; set; }
        public string HospitalSettingValue { get; set; }
    }

    public class Nurse : Entity
    {
        public int NurseID { get; set; }
        public int WardID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    public class Other_Services : Entity
    {
        public int OtherServicesID { get; set; }
        public string OtherServicesDate { get; set; }
        public int HospitalSettingID { get; set; }
        public int PatientID { get; set; }
    }

    public class Doctor_Patient_Visit : Entity
    {
        public int VisitID { get; set; }
        public string VisitType { get; set; }
        public string VisitDate { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

    }


    public class Patient_Medicine : Entity
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public decimal MedicineCost { get; set; }
        public string MedicineDate { get; set; }
    }
    public class Patient_Room : Entity
    {
        public int PatientID { get; set; }
        public int WardID { get; set; }
        public int RoomID { get; set; }
        public string PatientRoomDate { get; set; }
    }
    public class Room : Entity
    {
        public int RoomID { get; set; }
        public int WardID { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }
        public decimal RoomCharge { get; set; }
    }
    public class Ward : Entity
    {
        public int WardID { get; set; }
        public string WardName { get; set; }
    }
    public class Wardboy : Entity
    {
        public int WordboyID { get; set; }
        public int WardID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }


}