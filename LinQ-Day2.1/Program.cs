public class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int HospitalId { get; set; }


    public Patient(int id, string name, int age,int hospitalId)
    {
        PatientId = id;
        Name = name;
        Age = age;
        HospitalId = hospitalId;
    }
}
public class MedicalRecord
{
    public int RecordId { get; set; }
    public int PatientId { get; set; }
    public string Diagnosis { get; set; }
    public DateTime VisitDate { get; set; }
    public int HospitalId { get; set; }

    public MedicalRecord(int recordId, int patientId, string diagnosis, DateTime visitDate, int hospitalId)
    {
        RecordId = recordId;
        PatientId = patientId;
        Diagnosis = diagnosis;
        VisitDate = visitDate;
        HospitalId = hospitalId;
    }
}
public class Hospital
{
    public int HospitalId { get; set; }
    public string HospitalName { get; set; }

    public Hospital(int hospitalId,  string hospitalName)
    {
        HospitalId = hospitalId;
        HospitalName = hospitalName;
    }

}

public class HospitalManagement
{
    public static void Main(string[] arg)
    {
     
        List<Patient> patients = new List<Patient>
        {
            new Patient(1,"Rajvi Patel",23),
            new Patient(2,"Khushi Patel",22),
            new Patient(3,"Prachi Shah",25),
            new Patient(4,"Jiya Patel",21)
        };

        List<Patient> patients1 = new List<Patient>
        {
            new Patient(5,"Deep Patel",27),
            new Patient(6,"Rajvi Patel",23),
            new Patient(7,"Jiya Patel",21)
        };
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>
        {
            new MedicalRecord(1,1,"Flu",new DateTime(2025,1,5),101),
            new MedicalRecord(2,2,"Cold",new DateTime(2025,2,5),101),
            new MedicalRecord(3,3,"Stomach Ache",new DateTime(2025,3,5),102),
            new MedicalRecord(4,4,"Fever",new DateTime(2025,4,5),102),
            new MedicalRecord(5,1,"cold",new DateTime(2025,5,5),101)
        };

       
    }
}


