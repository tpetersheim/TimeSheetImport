using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TimeSheetImport
{
    internal class TimeSheetBackup
    {
        public List<TimeSheetBreak> Breaks;
        public List<TimeSheetNote> Notes;
        public List<TimeSheetProject> Projects;
        public List<TimeSheetTag> Tags;
        public List<TimeSheetTaskTag> TaskTags;
        public List<TimeSheetTask> Tasks;

        public TimeSheetBackup(string backupFilePath)
        {
            Breaks = new List<TimeSheetBreak>();
            Notes = new List<TimeSheetNote>();
            Projects = new List<TimeSheetProject>();
            Tags = new List<TimeSheetTag>();
            TaskTags = new List<TimeSheetTaskTag>();
            Tasks = new List<TimeSheetTask>();

            load(backupFilePath);
        }

        private bool validate(string backupFilePath)
        {
            bool valid = false;

            if (File.Exists(backupFilePath))
            {
                valid = true;
            }

            return valid;
        }

        private void load(string backupFilePath)
        {
            if (validate(backupFilePath))
            {
                try
                {
                    XElement backupXEl = XElement.Load(backupFilePath);
                    Breaks = (from tsBreak in backupXEl.Descendants("break")
                              select XElementToObject<TimeSheetBreak>(tsBreak)
                             ).ToList();
                    Notes = (from note in backupXEl.Descendants("note")
                              select XElementToObject<TimeSheetNote>(note)
                             ).ToList();
                    Projects = (from project in backupXEl.Descendants("project")
                                select XElementToObject<TimeSheetProject>(project)
                               ).ToList();
                    Tags = (from tag in backupXEl.Descendants("tag")
                            select XElementToObject<TimeSheetTag>(tag)
                           ).ToList();
                    TaskTags = (from taskTag in backupXEl.Descendants("taskTag")
                                select XElementToObject<TimeSheetTaskTag>(taskTag)
                               ).ToList();
                    Tasks = (from tasks in backupXEl.Descendants("task")
                             select XElementToObject<TimeSheetTask>(tasks)
                            ).ToList();

                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("There was an error processing the backup file. Select a valid file.", "Invalid file");
                    ShowError(ex);
                }
            }
            else
            {
                MessageHelper.ShowError("The Time Sheet backup file does not exist.", "Invalid file");
            }

        }

        public List<TimeSheetTask> GetTasksWithinTimeframe(DateTime startDate, DateTime endDate)
        {
            return (from task in Tasks
                    where task.StartDateParsed.Date >= startDate && task.EndDateParsed.Date <= endDate
                    select task).ToList();
        }

        public List<TimeSheetTag> GetTags(string taskId)
        {
            return (from tag in Tags
                    join taskTag in TaskTags on tag.TagId equals taskTag.TagId
                    where taskTag.TaskId == taskId
                    select tag).ToList();
                    
        }

        public TimeSheetNote GetNote(string taskId)
        {
            return (from note in Notes
                    where note.TaskId == taskId
                    select note).First();
        }

        public TimeSheetProject GetProject(string taskId)
        {
            return (from project in Projects
                    join task in Tasks on project.ProjectId equals task.ProjectId
                    where task.TaskId == taskId
                    select project).First();
        }

        public List<TimeSheetBreak> GetBreaks(string taskId)
        {
            return (from brk in Breaks
                    where brk.TaskId == taskId
                    select brk).ToList();
        }

        /// <summary>
        /// Converts XElement to a serializable object
        /// </summary>
        /// <typeparam name="T">Type of serializable object</typeparam>
        /// <param name="xEl">XElement making up the object</param>
        /// <returns>Resulting object of type T</returns>
        private T XElementToObject<T>(XElement xEl)
        {
            StringReader reader = new StringReader(xEl.ToString());
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            var obj = (T)xmlSerializer.Deserialize(reader);

            return (T)obj;
        }


        private void ShowError(Exception ex)
        {
            MessageBox.Show("TimeSheetBackup runtime error: " + Environment.NewLine + Environment.NewLine 
                + ex.ToString(), "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
