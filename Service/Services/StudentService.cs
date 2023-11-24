﻿using Domain.Models;
using Repository.Enums;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
      private readonly IStudentRepository _studentRepository;
       private List<Student> students = new List<Student>();
        public StudentService()
        {
            _studentRepository=new StudentRepository();
        }
        public void Create(Student student)
        {
           _studentRepository.Create(student);
        }
        public void Delete(Student student)
        {
           _studentRepository.Delete(student);
        }

        public void Edit(int id, Student student)
        {
            _studentRepository.Edit(id, student);
        }

        public List<Student> GetAll()
        {
          return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
           return _studentRepository.GetById(id);
        }

        public List<Student> Search(string fullname)
        {
           return _studentRepository.Search(fullname);
        }

        public List<Student> Sorting(SortType sort)
        {
          return _studentRepository.Sorting(sort);
        }
        public bool AddStudentToGroup(Student student, Group group)
        {
            if (students.Count <= group.Capacity)
            {
                students.Add(student);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
