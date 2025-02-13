//LINQ DAY 1 TASK

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Nullable<int> Age { get; set; }
    public string Disease { get; set; }
    public List<string> Doctors { get; set; }

 public Patient(int id,string name,Nullable<int> age,string disease, List<string> doctors)
{
        Id = id;
        Name = name;
        Age = age;
        Disease = disease;
        Doctors = doctors;
}
}
public class PatientManagement
{
    public static List<Patient> patients = new List<Patient>
    {
        new Patient(1, "Rajesh Patel", 45, "Cancer", new List<string> { "Dr. Shah", "Dr. Sharma"}),
        new Patient(2, "Jinal Shah", 50, "Heart Disease", new List<string> { "Dr. Rajput" }),
        new Patient(3, "Manisha Patel", 60, "Diabetes", new List<string> { "Dr. Patel" }),
        new Patient(4, "Asha Patel", 30, "Asthma", new List<string> { "Dr. Prajapati", "Dr. Rajput" }),
        new Patient(5, "Chetna Varma", 40, "Cancer", new List<string> { "Dr. Shah" }),
        new Patient(6, "Aneri Panchal", 55, "Hypertension", new List<string> { "Dr. Sharma" }),
        new Patient(7, "Ruhi Patel", 37, "Flu", new List<string> { "Dr. Shah" }),
        new Patient(8, "Ramesh Shah ", 45, "Cold", new List<string> { "Dr. Patel" }),
        new Patient(9, "Lankesh Rajput", 52, "Pneumonia", new List<string> { "Dr. Prajapati", "Dr. Shah" ,"Dr. Rajput" }),
        new Patient(10, "Soniya Prajapati", 60, "Osteoarthritis", new List<string> { "Dr. Rajput" }),
        new Patient(11, "Baldev Rathod", 70, "Parkinson's", new List<string> { "Dr. Sharma", "Dr. Rajput" }),
        new Patient(12, "Kush Patel", 22, "Migraine", new List<string> { "Dr. Prajapati" }),
        new Patient(13, "Manish Shah", 29, "Insomnia", new List<string> { "Dr. Patel" }),
        new Patient(14, "Ella Gohil", 43, "Cancer", new List<string> { "Dr. Shah", "Dr. Sharma" }),
        new Patient(15, "Paresh Patel", 55, "Diabetes", new List<string> { "Dr. Patel" }),
        new Patient(16, "Isa Patel", 38, "Flu", new List<string> { "Dr. Prajapati" }),
        new Patient(17, "Dinesh Shah", 65, "Heart Disease", new List<string> { "Dr. Rajput" }),
        new Patient(18, "Maniya Sharma", 49, "Hypertension", new List<string> { "Dr. Smith" }),
        new Patient(19, "Masoom Patel", 62, "Cold", new List<string> { "Dr. Patel" }),
        new Patient(20, "Ami Varma", 34, "Pneumonia", new List<string> { "Dr. Rajput" })
    };

static void Main(string[] args)

{
        var AllPatients = patients.Select(p => new {
            id = p.Id,
            name = p.Name,
            age = p.Age,
            disease = p.Disease,
            doc = string.Join(",", p.Doctors)
        });
        foreach (var patient in AllPatients)
        {
            Console.WriteLine($"Id: {patient.id}, Name: {patient.name}, Age: {patient.age}, Disease: {patient.disease}, Doctors: " +
                $"{patient.doc}");


        }

        Console.WriteLine("\n**************************************************************************");


        // 1. Get patients above the age of 40

        var patientsAbove40 = patients.Where(p => p.Age > 40);
        Console.WriteLine("Patients above the age of 40:");
             foreach (var patient in patientsAbove40)
                {
                      Console.WriteLine(patient.Name);
                 }

        var patientAbove40Query= from p in patients
                                 where p.Age >40
                                 select p;

        Console.WriteLine("\n**************************************************************************");

    // 2. Retrieve patient names along with their assigned doctors

        var patientsWithDoctors = patients.Select(p => new { p.Name, Doctors = string.Join(", ", p.Doctors) });
        Console.WriteLine("\nPatient names and their assigned doctors:");
            foreach (var patient in patientsWithDoctors)
                {
                    Console.WriteLine($"{patient.Name} - {patient.Doctors}");
                }

        var patientsWithDoctorsQuery = from p in patients
                                       select new { p.Name, Doctors = string.Join(", ", p.Doctors) };

        Console.WriteLine("\n**************************************************************************");


     // 3. Use SelectMany to get a flat list of all doctors treating patients
     
         var allDoctors = patients.SelectMany(p => p.Doctors).Distinct();
         Console.WriteLine("\nList of all unique doctors:");
            foreach (var doctor in allDoctors)
                {
                    Console.WriteLine(doctor);
                }

         var allDoctorsQuery= from p in patients
                              from doctor in p.Doctors
                              select doctor;

        Console.WriteLine("\n**************************************************************************");



      // 4. Find the total number of patients
        
        var totalPatients = patients.Count();
         Console.WriteLine($"\nTotal number of patients: {totalPatients}");

        var totalpatientsQuery = (from p in patients select p).Count();

        Console.WriteLine("\n**************************************************************************");


      // 5. Get patients sorted by age, then by name
     
        var sortedPatients = patients.OrderBy(p => p.Age).ThenBy(p => p.Name);
        Console.WriteLine("\nPatients sorted by age, then by name:");
             foreach (var patient in sortedPatients)
                 {
                    Console.WriteLine($"{patient.Name} - Age: {patient.Age}");
                 }

        var sortedpatientsQuery= from p in patients
                                 orderby p.Age, p.Name
                                 select p;

        Console.WriteLine("\n**************************************************************************");


     // 6. Find the most common disease
     
        var mostCommonDisease = patients.GroupBy(p => p.Disease).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
        Console.WriteLine($"\nMost common disease: {mostCommonDisease}");



        var mostCommonDiseaseQuery = (from p in patients
                                      group p by p.Disease into diseaseGroup
                                      orderby diseaseGroup.Count() descending
                                      select diseaseGroup.Key).FirstOrDefault();

        Console.WriteLine("\n**************************************************************************");


     // 7. Retrieve patients grouped by disease type
       
        var patientsGroupedByDisease = patients.GroupBy(p => p.Disease);
        Console.WriteLine("\nPatients grouped by disease type:");
            foreach (var group in patientsGroupedByDisease)
                {
                    Console.WriteLine($"{group.Key}:");
                    foreach (var patient in group)
                        {
                            Console.WriteLine($"  - {patient.Name}");
                        }
                }

       var patientsGroupedByDiseaseQuery= from p in patients
                                          group p by p.Disease;

        Console.WriteLine("\n**************************************************************************");


     // 8. Find the average age of patients (handling nullable values)
        
        var averageAge = patients.Where(p => p.Age.HasValue).Average(p => p.Age.Value);
        Console.WriteLine($"\nAverage age of patients: {averageAge}");

        var averageAgeQuery = (from p in patients
                              where p.Age.HasValue
                              select p.Age.Value).Average();

        Console.WriteLine("\n**************************************************************************");


    // 9. Count how many patients each doctor is treating
        
        var doctorPatientCount = patients.SelectMany(p => p.Doctors).GroupBy(doctor => doctor).Select(group => new { Doctor = group.Key, PatientCount = group.Count() });
        Console.WriteLine("\nHow many patients each doctor is treating:");
            foreach (var doctor in doctorPatientCount)
                {
                    Console.WriteLine($"{doctor.Doctor}: {doctor.PatientCount} patients");
                }

        var doctorPatientCountQuery = from p in patients
                                      from doctor in p.Doctors
                                      group doctor by doctor into doctorGroup
                                      select new { Doctor = doctorGroup.Key, patientCount = doctorGroup.Count() };

        Console.WriteLine("\n**************************************************************************");


    // 10. Find the patient(s) with the longest list of doctors
    
        var patientWithMostDoctors = patients.OrderByDescending(p => p.Doctors.Count).FirstOrDefault();
        Console.WriteLine($"\nPatient with the longest list of doctors:");
            if (patientWithMostDoctors != null)
                {
                    Console.WriteLine($"{patientWithMostDoctors.Name} - {string.Join(", ", patientWithMostDoctors.Doctors)}");
                }

        var patientWithMostDoctorQuery= (from p in patients
                                         orderby p.Doctors.Count descending
                                         select p).FirstOrDefault();

        Console.WriteLine("\n**************************************************************************");

    }
}