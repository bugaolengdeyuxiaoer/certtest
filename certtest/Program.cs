// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;


// Open the root certificate store
X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
store.Open(OpenFlags.ReadOnly);



foreach (X509Certificate2 cert in store.Certificates)
{
    Console.WriteLine(cert.SubjectName.Name);
}

// Find the root certificate by its subject name
X509Certificate2Collection certs = store.Certificates.Find(
    X509FindType.FindBySubjectName, "CN=ameroot, DC=AME, DC=GBL", true);

// Get the first matching certificate
if (certs.Count() > 0)
{
    X509Certificate2 cert = certs[0];
    Console.WriteLine(cert.SubjectName.Name);
}
else
{
    Console.WriteLine("NotFound");
}

// Close the certificate store
store.Close();
Console.WriteLine("Hello, World!");
Console.ReadLine();
