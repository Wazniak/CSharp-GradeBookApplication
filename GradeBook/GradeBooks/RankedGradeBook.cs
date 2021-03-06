using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidCastException();

            var studentsCount = Students.Count;
            var threshold = (int) Math.Ceiling(0.2 * studentsCount);
            var allGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (allGrades[threshold - 1] <= averageGrade) return 'A';
            else if (allGrades[(threshold * 2) - 1] <= averageGrade) return 'B';
            else if (allGrades[(threshold * 3) - 1] <= averageGrade) return 'C';
            else if (allGrades[(threshold * 4) - 1] <= averageGrade) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(
                    "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(
                    "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}