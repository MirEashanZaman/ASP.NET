namespace Pre_Requisite_Task_2.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public string DisplayInfo()
        {
            return "ID: " + ID + " | Name: " + Name + " | Department: " + Department;
        }
    }
}