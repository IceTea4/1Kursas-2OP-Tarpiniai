using System;

namespace Univeras
{
	public class FacultyRegister
	{
        public string faculty { get; }
        public StudentsContainer students { get; }

        public FacultyRegister(string faculty)
        {
            this.faculty = faculty;
            this.students = new StudentsContainer();
        }
    }
}

