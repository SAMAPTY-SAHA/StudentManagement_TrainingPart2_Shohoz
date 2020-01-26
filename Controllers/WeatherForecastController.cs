using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services;
using StudentManagement_asp.netWebApi_.Models;

namespace StudentManagement_asp.netWebApi_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {


        //IStudentRepository _studentRepository;
        IStudentService _studentService;
        //IDataBaseSettings _dataBaseSettings;
        public HomeController(IStudentService studentService)
        {
            // _studentRepository = studentRepository;
            //_dataBaseSettings = dataBaseSettings;
            _studentService = studentService;
        }
        
        public string  Index()
        {
            // return _studentRepository.GetStudent(1).name;
            //var model = _studentRepository.getAllStudent();
            var model = _studentService.getAllStudent();
            string json = JsonConvert.SerializeObject(model);
            return json;     

        }
        [HttpGet("{id}")]
        public String  Details(String  id)
        {
            // Student student = _studentRepository.GetStudent(id ?? 1);
            //StudentService studentService = _studentService.GetStudent(id ?? 1);
            Student student = _studentService.GetStudent(id);
            string json = JsonConvert.SerializeObject(student);
            return json;          
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(string id)
        {
            // Student newSt = _studentRepository.GetStudent(id);
            Student newSt = _studentService.GetStudent(id);
            // _studentRepository.delete(newSt);
            _studentService.delete(id);
            return RedirectToAction("Index");
        }

       [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //  Student newStudent = _studentRepository.Add(student);
            Student newStudent = _studentService.Add(student);
            return Ok(newStudent);

            //return RedirectToAction("Details", new { id = newStudent.ID });       
        }
        
       [HttpPut("{id}")]
        public IActionResult Edit(String id,Student student)
        {
            // Student newSt = _studentRepository.GetStudent(id);
            Student newSt = _studentService.GetStudent(id);
            if (newSt != null)
            {
                // _studentRepository.update(student);
                _studentService.update(student,id);
            }
            
            return Ok(student);

        }



    }
}
