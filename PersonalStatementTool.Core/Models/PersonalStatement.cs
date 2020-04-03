using Stylet;

namespace PersonalStatementTool.Core
{
    public class PersonalStatement : PropertyChangedBase
    {
        #region Backing Fields
        private string _author;
        private string _courseViewText;
        private string _skillsViewText;
        private string _workExperienceViewText;
        private string _fullText;
        #endregion
        #region Properties
        public string Author
        {
            get => _author; 
            set { _author = value; SetAndNotify(ref this._author, value); }
        }
        public string CourseViewText
        {
            get => _courseViewText; 
            set { _courseViewText = value; SetAndNotify(ref this._courseViewText, value); }
        }
        public string SkillsViewText
        {
            get => _skillsViewText;
            set { _skillsViewText = value; SetAndNotify(ref this._skillsViewText, value); }
        }
        public string WorkExperienceViewText
        {
            get => _workExperienceViewText;
            set { _workExperienceViewText = value; SetAndNotify(ref this._workExperienceViewText, value); }
        }
        public string FullText
        {
            get => _fullText;
            set { _fullText = value; SetAndNotify(ref this._fullText, value); }
        }
        #endregion
    }
}
