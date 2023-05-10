using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;

using (var universityContext = new UniversityContext())
{
    #region insert
    //inserting a student
    //creating document/record of student
    var studentMickey = new Student()
    {
        Id = "7",
        Name= "Mike Doe",
        Age =21,
        Gender="male",
        Major= "Computer Engineering",
        GPA= 3.5,
        ExtracurricularActivities= new List<string>(){
            "Robotics Club", "Coding Club"
        } 
    };
    universityContext.Students?.Add(studentMickey);

    //wait for save
    await universityContext.SaveChangesAsync();
    #endregion

    #region Get students Names

    if (universityContext.Students != null)
    {

        var students = await universityContext.Students.ToListAsync();
        if (students != null)
        {
            
            foreach (var student in students)
            {
                Console.WriteLine("Name : " + student.Name);
                Console.WriteLine("--------------------------------\n");
            }
        }
    }
    
    #endregion

    #region Get first student Name who is aged 19

    if(universityContext.Students != null)
    {
        var student19 = await universityContext.Students.Where(s => s.Age == 19).FirstOrDefaultAsync();
        Console.WriteLine("");
          

        if(student19!= null){
            Console.WriteLine("Name of student aged 19 : " + student19.Name);
            Console.WriteLine("--------------------------------\n");
        }
            
        
    }

    #endregion

    #region Update a student

    if (universityContext.Students != null)
    {
        var student = await universityContext.Students
            .Where(s => s.Name == "John Smith")
            .FirstOrDefaultAsync();

        if(student != null)
        {
            Console.WriteLine("student id is "+student.Id+ " student old major is " + student.Major);
            student.Major = "Gender Studies";
            

            await universityContext.SaveChangesAsync();
            
            Console.WriteLine("\nRecord has been updated.\n");
            Console.WriteLine("student id is "+student.Id+ " student new major is " + student.Major);
        }        
    }
    
    #endregion

#region Delete a student

    if (universityContext.Students != null)
    {
        var student = await universityContext.Students
            .Where(s => s.Major == "Gender Studies")
            .FirstOrDefaultAsync();

        if(student != null)
        {
            universityContext.Students.Remove(student);
            await universityContext.SaveChangesAsync();
            
            Console.WriteLine("\nRecord has been deleted.\n");
        }        
    }

#endregion

}