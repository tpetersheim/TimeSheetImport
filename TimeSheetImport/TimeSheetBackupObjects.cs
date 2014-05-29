using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimeSheetImport
{
    [Serializable()]
    [XmlRoot(ElementName = "break")]
    public class TimeSheetBreak
    {
        public TimeSheetBreak()
        { }

        [XmlElement("breakId")]
        public string BreakId { get; set; }
        [XmlElement("taskId")]
        public string TaskId { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("startDate")]
        public string StartDate { get; set; }
        public DateTime StartDateParsed { get { return DateTime.Parse(StartDate); } }
        [XmlElement("endDate")]
        public string EndDate { get; set; }
        public DateTime EndDateParsed { get { return DateTime.Parse(EndDate); } }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

    [Serializable()]
    [XmlRoot(ElementName = "note")]
    public class TimeSheetNote
    {
        public TimeSheetNote()
        { }

        [XmlElement("noteId")]
        public string NoteId { get; set; }
        [XmlElement("taskId")]
        public string TaskId { get; set; }
        [XmlElement("text")]
        public string Text { get; set; }
        [XmlElement("startDate")]
        public string DateAndTime { get; set; }
        public DateTime DateAndTimeParsed { get { return DateTime.Parse(DateAndTime); } }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

    [Serializable()]
    [XmlRoot(ElementName = "project")]
    public class TimeSheetProject
    {
        public TimeSheetProject()
        { }

        [XmlElement("projectId")]
        public string ProjectId { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        public string NameTrimmed { get { return Name.Trim(); } }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("status")]
        public string Status { get; set; }
        public int StatusParsed { get { return int.Parse(Status); } }
        [XmlElement("salary")]
        public string Salary { get; set; }
        public double SalaryParsed { get { return double.Parse(Salary); } }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

    [Serializable()]
    [XmlRoot(ElementName = "tag")]
    public class TimeSheetTag
    {
        public TimeSheetTag()
        { }

        [XmlElement("tagId")]
        public string TagId { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        public string NameTrimmed { get { return Name.Trim(); } }
        public string NameStripped { get { return (new Regex("[^a-zA-Z0-9]")).Replace(Name, ""); } }
        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

    [Serializable()]
    [XmlRoot(ElementName = "taskTag")]
    public class TimeSheetTaskTag
    {
        public TimeSheetTaskTag()
        { }

        [XmlElement("taskId")]
        public string TaskId { get; set; }
        [XmlElement("tagId")]
        public string TagId { get; set; }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

    [Serializable()]
    [XmlRoot(ElementName = "task")]
    public class TimeSheetTask
    {
        public TimeSheetTask()
        { }

        [XmlElement("taskId")]
        public string TaskId { get; set; }
        [XmlElement("projectId")]
        public string ProjectId { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        public string DescriptionTrimmed { get { return Description.Trim(); } }
        [XmlElement("location")]
        public string Location { get; set; }
        [XmlElement("startDate")]
        public string StartDate { get; set; }
        public DateTime StartDateParsed { get { return DateTime.Parse(StartDate); } }
        [XmlElement("endDate")]
        public string EndDate { get; set; }
        public DateTime EndDateParsed { get { return DateTime.Parse(EndDate); } }


        [XmlElement("paid")]
        public string Paid { get; set; }
        public int PaidParsed { get { return int.Parse(Paid); } }
        [XmlElement("feeling")]
        public string Feeling { get; set; }
        public int FeelingParsed { get { return int.Parse(Feeling); } }

        [XmlElement("deleted")]
        public string Deleted { get; set; }
        public bool DeletedParsed { get { return bool.Parse(Deleted); } }
    }

}
