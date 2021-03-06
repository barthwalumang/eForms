﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Eform1.models;
using Eform1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eform1.controllers
{
    public class HomeController : Controller
    {
        public IFormRepository _formRepository;

        public HomeController(IFormRepository formRepository)
        {
            _formRepository = formRepository;

        }
        public IActionResult Index()
        {
           // _formRepository.Remove_2(279432155);

            /*table_3 Table_3 = new table_3();
            Table_3.F2 = 279432155;
            Table_3.ID_MCQ = 1;
            Table_3.UID_Q = 0;
            Table_3.Options = "yoyo";
            _formRepository.Update_3(Table_3);
            */
            return View();
        }

        [HttpGet]
        public ViewResult CreateForm(string? val)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateForm( )
        {
            Random va = new Random();
            table_1 Table_1 = new table_1();
            Table_1.UID_F = va.Next();
            Table_1.Form_Name = Request.Form["form-name"];
            Table_1.Creator = Request.Form["creators-name"];
            Table_1.Created_On = DateTime.Now.ToString("h:mm:ss ");
            _formRepository.Add_1(Table_1);

            table_2 Table_2 = new table_2();
            int i = 0;
            while (true)
            {
                if (!string.IsNullOrEmpty(Request.Form[$"ques-{i}"]))
                {
                    Table_2.UID_F1 = Table_1.UID_F;
                    Table_2.UID_Q = i;
                    Table_2.Question_Type = Request.Form[$"sel-{i}"];
                    Table_2.Question = Request.Form[$"ques-{i}"];
                    _formRepository.Add_2(Table_2);



                    if (Table_2.Question_Type == "radio" || Table_2.Question_Type == "checkbox")
                    {
                        table_3 Table_3 = new table_3();
                        int j = 1;
                        
                        while (true)
                        {
                            if (!string.IsNullOrEmpty(Request.Form[$"radio-{i}-{j}"]))
                            {
                            
                                Table_3.F2 = Table_1.UID_F;
                                Table_3.UID_Q = i;
                                Table_3.ID_MCQ = j;
                                Table_3.Options = Request.Form[$"radio-{i}-{j}"];
                                _formRepository.Add_3(Table_3);
                                j++;
                            }
                            else
                                break;

                        }

                    }
                    i++;
                }
                else
                    break;

            }
            return RedirectToAction("Results", new { id = Table_1.UID_F });  // return View();
        }
       
        public ActionResult Results(int id)
        {
           // tmp = 656501304;
            FormModelView formModelView = new FormModelView();
            formModelView.Table_1 = _formRepository.GetAll1(id);
            formModelView.list_2 = _formRepository.GetAll2(id);
            formModelView.list_3 = _formRepository.GetAll3(id);  
            return View(formModelView);
        }
        }



    /* Formdumy formdumy = new Formdumy();
         formdumy.FormName = Request.Form["radio-0-1"];
         formdumy.FormName1 = Request.Form["radio-1-2"];
         formdumy.radio = Request.Form["radio-1-1"];
         return RedirectToAction("Results", "Home", formdumy);

         ViewBag.str = formdumy.FormName;
            ViewBag.str1 = formdumy.FormName1;
            ViewBag.str2 = formdumy.radio;


           return Content($"hello {formData.Agree}");
         */



}
