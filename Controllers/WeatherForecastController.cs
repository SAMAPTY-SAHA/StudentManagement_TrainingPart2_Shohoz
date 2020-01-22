using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentManagement_asp.netWebApi_.Models;

namespace StudentManagement_asp.netWebApi_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        IStudentRepository _studentRepository;
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        public string  Index()
        {
            // return _studentRepository.GetStudent(1).name;
            var model = _studentRepository.getAllStudent();
            string json = JsonConvert.SerializeObject(model);
            return json;     

        }
        [HttpGet("{id}")]
        public String  Details(int? id)
        {
            Student student = _studentRepository.GetStudent(id ?? 1);
            string json = JsonConvert.SerializeObject(student);
            return json;          
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            Student newSt = _studentRepository.GetStudent(id);
            _studentRepository.delete(newSt);
            return RedirectToAction("Index");
        }

       [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            Student newStudent = _studentRepository.Add(student);
            return Ok(newStudent);

            //return RedirectToAction("Details", new { id = newStudent.ID });       
        }
        
       [HttpPut("{id}")]
        public IActionResult Edit(int id,Student student)
        {
            Student newSt = _studentRepository.GetStudent(id);
            if (newSt != null)
            {
                _studentRepository.update(student);
            }
            
            return Ok(student);

        }



    }
}
