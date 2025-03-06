using System.Text.RegularExpressions;

public class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
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
    public static void Main(string[] arg)
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient(1,"Rajvi Patel",23),
            new Patient(2,"Khushi Patel",22),
            new Patient(3,"Prachi Shah",25),
            new Patient(4,"Jiya Patel",21),
            new Patient(5,"Sahil Patel",19)
        };

        List<Patient> patients1 = new List<Patient>
        {
            new Patient(6,"Deep Patel",27),
            new Patient(7,"Rajvi Patel",23),
            new Patient(8,"Jiya Patel",21)
        };
        List<MedicalRecord> medicalRecords = new List<MedicalRecord>
        {
            new MedicalRecord(1,1,"Flu",new DateTime(2025,1,5),101),
            new MedicalRecord(2,2,"Cold",new DateTime(2025,2,5),101),
            new MedicalRecord(3,3,"Stomach Ache",new DateTime(2025,3,5),101),
            new MedicalRecord(4,4,"Fever",new DateTime(2025,4,5),102),
            new MedicalRecord(5,5,"Headache",new DateTime(2025,5,5),101),
            new MedicalRecord(6,6,"Malaria",new DateTime(2025,6,5),101),
            new MedicalRecord(7,7,"Typhoid",new DateTime(2025,7,5),101),
            new MedicalRecord(8,8,"Diarrhoea",new DateTime(2025,8,5),102),
            new MedicalRecord(9,1,"Diabetes",new DateTime(2025,2,8),101),
            new MedicalRecord(10,2,"Cold",new DateTime(2025,4,5),102),
            new MedicalRecord(11,3,"Cold",new DateTime(2025,4,5),101),
            new MedicalRecord(12,2,"Cold",new DateTime(2025,4,5),101),
            new MedicalRecord(13,3,"Cold",new DateTime(2025,4,5),101)

        };


        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n1 Query");


        // 1. Generate a list of all patients along with their medical history, ensuring that even those without records appear in the output.

        //Method syntax
        var patientsWithHistory = patients.GroupJoin(medicalRecords, patients => patients.PatientId,
            record => record.PatientId, (patients, records) => new
            {
                PatientName = patients.Name,
                MedicalHistory = records.DefaultIfEmpty()
            }).ToList();

        Console.WriteLine("Patients with their medical history:");
        foreach (var p in patientsWithHistory)
        {
            Console.WriteLine($"{p.PatientName}: {p.MedicalHistory?.FirstOrDefault()?.Diagnosis ?? "No records"}");
        }

        //Query syntax
        var patientWithHistory = from patient in patients
                                 join record in medicalRecords on patient.PatientId equals record.PatientId into patientRecords
                                 from record in patientRecords.DefaultIfEmpty()
                                 select new
                                 {
                                     PatientName = patient.Name,
                                     MedicalHistory = record
                                 };

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n2 Query");

        // 2. Construct a dataset that pairs every patient with every available medical record, regardless of any relationship.

        //Method syntax
        var patientMedicalPairs = patients.SelectMany(
            patient => medicalRecords, (patient, record) => new
            {
                PatientName = patient.Name,
                Diagnosis = record.Diagnosis
            }).Distinct().ToList();

        Console.WriteLine("\nPatient/Medical Record pairs:");
        foreach (var pair in patientMedicalPairs)
        {
            Console.WriteLine($"{pair.PatientName}: {pair.Diagnosis}");
        }

        //Query syntax
        var patientMedicalpairs = (from patient in patients
                                  from record in medicalRecords
                                  select new
                                  {
                                      PatientName = patient.Name,
                                      Diagnosis = record.Diagnosis
                                  }).Distinct();

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n3 Query");

        //3.Modify the first query so that all patients appear, even if they have no medical records.

        //Method syntax
        var patientsWithHistory2 = patients
            .GroupJoin(
                    medicalRecords,
                    patient => patient.PatientId,
                    record => record.PatientId,
                    (patient, records) => new
                    {
                        PatientName = patient.Name,
                        MedicalHistory = records.DefaultIfEmpty()
                    }
             )
            .SelectMany(
                    g => g.MedicalHistory,
                    (patient, record) => new
                    {
                        patientname = patient.PatientName,
                        Diagnosis = record?.Diagnosis ?? "no Medical Record",
                        VisitDate = record?.VisitDate.ToString("yyyy-MM-dd") ?? "n/a"
                    }
             );

        Console.WriteLine("Patients with their medical history:");
        foreach (var p in patientsWithHistory2)
        {
            Console.WriteLine(p);

        }

        //Query syntax
        var patientsWithHistory3 = from patient in patients
                                   join record in medicalRecords
                                   on patient.PatientId equals record.PatientId
                                   into patientRecords
                                   from record in patientRecords.DefaultIfEmpty()
                                   select new
                                   {
                                       PatientName = patient.Name,
                                       Diagnosis = record?.Diagnosis ?? "No Medical Record",
                                       VisitDate = record?.VisitDate.ToString("yyyy-MM-dd") ?? "N/A"
                                   };

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n4 Query");


        //4.Create a LINQ query to fetch patient names, but defer its execution until later.
        //Modify the dataset before execution and observe any changes in the result.


        //Deferred Execution
        //Method syntax
        var deferredQuery = patients.Select(p => p.Name);
        patients.Add(new Patient(5, "Neha Sharma", 26));
        Console.WriteLine("Patient Names (Deferred Execution):");
        foreach (var name in deferredQuery)
        {
            Console.WriteLine(name);
        }

        //Query syntax
        var deferredQuerySyntax = from p in patients select p.Name;
        patients.Add(new Patient(6, "Parth Patel", 27));
        Console.WriteLine("\nPatient Names (Deferred Execution)");
        foreach (var name in deferredQuerySyntax)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n5 Query");


        //5.Convert the query to execute immediately and compare the differences.


        //Immediate Execution 
        var immediateExecution = patients.Select(p => p.Name).ToList();
        patients.Add(new Patient(6, "Ananya Gupta", 30));
        Console.WriteLine("\nPatient Names (Immediate Execution):");
        foreach (var name in immediateExecution)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n**************************************************************************");

        //Deferred Execution 
        var deferredQuery1 = patients.Select(p => p.Name);
        patients.Add(new Patient(5, "Neha Sharma", 26));
        Console.WriteLine("Patient Names (Deferred Execution):");
        foreach (var name in deferredQuery)
        {
            Console.WriteLine(name);
        }


        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n6 Query");

        //6.Retrieve a distinct list of medical conditions recorded in the system.
        //Method syntax
        var distinctConditions = medicalRecords
                         .Select(m => m.Diagnosis)
                         .Distinct()
                         .ToList();

        Console.WriteLine("Distinct Medical Conditions:");
        foreach (var condition in distinctConditions)
        {
            Console.WriteLine(condition);
        }

        //Query syntax
        var distinctConditionsQuery = (from m in medicalRecords
                                       select m.Diagnosis)
                               .Distinct()
                               .ToList();

        foreach (var condition in distinctConditionsQuery)
        {
            Console.WriteLine(condition);
        }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n7 Query");

        //7.Combine two separate patient lists (from different hospitals) while ensuring no duplicate patient names.

        // Method syntax
        var uniquePatients = patients.Concat(patients1).GroupBy(p => p.Name)
            .Select(g => g.First())
            .ToList();
        foreach (var p in uniquePatients)
        {
            Console.WriteLine($"{p.Name}, Age: {p.Age}");
        }

        //Query syntax
        var uniquePatientsQuery = (from p in patients.Concat(patients1)
                                   group p by p.Name into patientGroup
                                   select patientGroup.First())
                                 .ToList();

        foreach (var p in uniquePatientsQuery)
        {
            Console.WriteLine($"{p.Name}, Age: {p.Age}");
        }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n8 Query");


        //8.Identify patients who have visited both hospitals.
        //Method syntax
        var patientsVisitedBothHospitals = medicalRecords
            .GroupBy(r => r.PatientId)
            .Where(g => g.Select(r => r.HospitalId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .ToList();

        Console.WriteLine("Patients who visited both hospitals:");
        foreach (var patientId in patientsVisitedBothHospitals)
        {
            Console.WriteLine($"Patient ID: {patientId}");
        }


        //Query syntax
        var patientsVisitedBothHospitalsQuery = from record in medicalRecords
                                                group record by record.PatientId into patientRecords
                                                where patientRecords.Select(r => r.HospitalId).Distinct().Count() > 1
                                                select patientRecords.Key;

        foreach (var patientId in patientsVisitedBothHospitalsQuery)
        {
            Console.WriteLine($"Patient ID: {patientId}");
        }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n9 Query");


        //9 Find patients who have visited one hospital but not the other.
        //Method syntax
        var patientsInOneHospital = medicalRecords.GroupBy(r => r.PatientId)
               .Where(g => g.Select(r => r.HospitalId).Distinct().Count() == 1)
               .Select(g => g.Key)
               .ToList();

        Console.WriteLine("Patients who visited only one hospital:");
        foreach (var patientId in patientsInOneHospital)
        {
            Console.WriteLine($"Patient ID: {patientId}");
        }

        //Query syntax
        var patientsInOneHospitalQuery = from record in medicalRecords
                                         group record by record.PatientId into patientRecords
                                         where patientRecords.Select(r => r.HospitalId).Distinct().Count() == 1
                                         select patientRecords.Key;

        foreach (var patientId in patientsInOneHospitalQuery)
        {
            Console.WriteLine($"Patient ID: {patientId}");
        }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n10 Query");

        //10 List all patients who have visited the hospital more than twice, using a nested LINQ query.
        //Method syntax
        var frequentVisitors = medicalRecords.GroupBy(r => new { r.PatientId, r.HospitalId })
                .Where(g => g.Count() > 2)
                .Select(g => new { g.Key.PatientId, g.Key.HospitalId, VisitCount = g.Count() })
                .ToList();
        var frequentvisitorsquerysyntax = (from record in medicalRecords
                                          group record by new { record.PatientId, record.HospitalId } into groupedtable
                                          where groupedtable.Count() > 2
                                          select new
                                          {
                                              PatientId = groupedtable.Key.PatientId,
                                              HospitalId = groupedtable.Key.HospitalId,
                                              VisitCount = groupedtable.Count()
                                          }).ToList();

        Console.WriteLine("Patients who visited a hospital more than twice:");
        foreach (var record in frequentVisitors)
        {
            Console.WriteLine($"Patient ID: {record.PatientId}, Hospital ID: {record.HospitalId}, Visits: {record.VisitCount}");
        }

        //Query syntax
        var frequentVisitorsQuery = from record in medicalRecords
                                    group record by new { record.PatientId, record.HospitalId } into groupedRecords
                                    where groupedRecords.Count() > 2
                                    select new { groupedRecords.Key.PatientId, groupedRecords.Key.HospitalId, VisitCount = groupedRecords.Count() };

        foreach (var record in frequentVisitorsQuery)
        {
            Console.WriteLine($"Patient ID: {record.PatientId}, Hospital ID: {record.HospitalId}, Visits: {record.VisitCount}");
        }


        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n11 Query");


        //11.Categorize all patient records based on patient names, displaying the total number of visits per patient.
        //Method syntax
        var patientVisitCount = patients.GroupJoin(medicalRecords,
                  patient => patient.PatientId,
                  record => record.PatientId,
                 (patient, records) => new
                 {
                     PatientName = patient.Name,
                     TotalVisits = records.Count()
                 }).ToList();

        Console.WriteLine("Patient Visit Count:");
        foreach (var p in patientVisitCount)
        {
            Console.WriteLine($"{p.PatientName}: {p.TotalVisits} visits");
        }
        //Query syntax
        var patientVisitCountQuery = from patient in patients
                                     join record in medicalRecords on patient.PatientId equals record.PatientId into patientRecords
                                     select new
                                     {
                                         PatientName = patient.Name,
                                         TotalVisits = patientRecords.Count()
                                     };

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n12 Query");

        //12 Implement two different LINQ queries to achieve the same result and compare the outputs.
        //Method syntax 

        var deferredQuery2 = patients.Select(p => p.Name);
        patients.Add(new Patient(6, "Parth Patel", 27)); 

        Console.WriteLine("Patient Names (Deferred Execution):");
            foreach (var name in deferredQuery2) 
                { 
                     Console.WriteLine(name);
                }

        Console.WriteLine("\n**************************************************************************");

        var patientsLookup = patients.ToLookup(p => p.PatientId, p => p.Name);
        patients.Add(new Patient(7, "Neha Sharma", 26));

        Console.WriteLine("Patient Names (Using Lookup):");
        foreach (var nameGroup in patientsLookup)
            {
             foreach (var name in nameGroup)
                {
                  Console.WriteLine(name);
                }
            }

        Console.WriteLine("\n**************************************************************************");
        Console.WriteLine("\n13Query");

        //13 Retrieve a list of patients who have visited the hospital, displaying each patient’s name along with their latest diagnosis.
        //Ensure that only patients with a medical record are included.
        //Method syntax
        var latestDiagnoses = medicalRecords.GroupBy(r => r.PatientId)
                .Select(g => g.OrderByDescending(r => r.VisitDate).First())
                .Join(patients,
                      record => record.PatientId,
                      patient => patient.PatientId,
                      (record, patient) => new
                      {
                          PatientName = patient.Name,
                          LatestDiagnosis = record.Diagnosis,
                          LatestVisitDate = record.VisitDate.ToString("yyyy-MM-dd")
                      }).ToList();

        Console.WriteLine("Patients with their latest diagnosis:");
        foreach (var entry in latestDiagnoses)
        {
            Console.WriteLine($"Patient: {entry.PatientName}, Latest Diagnosis: {entry.LatestDiagnosis}, Visit Date: {entry.LatestVisitDate}");
        }

        //Query syntax
        var latestDiagnosesQuery = from record in medicalRecords
                                   group record by record.PatientId into groupedRecords
                                   let latestRecord = groupedRecords.OrderByDescending(r => r.VisitDate).First()
                                   join patient in patients on latestRecord.PatientId equals patient.PatientId
                                   select new
                                   {
                                       PatientName = patient.Name,
                                       LatestDiagnosis = latestRecord.Diagnosis,
                                       LatestVisitDate = latestRecord.VisitDate.ToString("yyyy-MM-dd")
                                   };

        foreach (var entry in latestDiagnosesQuery)
        {
            Console.WriteLine($"Patient: {entry.PatientName}, Latest Diagnosis: {entry.LatestDiagnosis}, Visit Date: {entry.LatestVisitDate}");
        }

    }
}
