using System;

public class Program
{
    public static void Main(string[] args)
    {
       
        Job job1 = new Job("Software Engineer (Microsoft) 2019-2022");
        Job job2 = new Job("Manager (Apple) 2022-2023");

        
        Resume myResume = new Resume();
        myResume._name = "Allison Rose"; 

        
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        
        myResume.Display();
    }
}
