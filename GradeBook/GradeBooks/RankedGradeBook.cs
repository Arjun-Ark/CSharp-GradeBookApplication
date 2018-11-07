using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            //transfer student grades to a list and sort
            var allGrades = new List<double>();
            foreach (var student in Students)
            {
                    allGrades.Add(student.AverageGrade);
            }

            allGrades = allGrades.OrderByDescending(i => i).ToList();

            //divide by 5 to determine the grade boundries
            int boundry = (int)Math.Ceiling(allGrades.Count * 0.2);
            
            //compare and return correct letter

            if (allGrades[boundry - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (allGrades[(boundry * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (allGrades[(boundry * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (allGrades[(boundry * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
            //top 20% of students get A
            //second 20% get B
            //third 20% get C
            //fourth 20% get D


            //otherwise, return F
          
        }
    }
}
