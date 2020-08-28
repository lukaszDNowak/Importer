using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Importer.DAL;
using Importer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace Importer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : Controller
    {
       
        private ImporterContext context = null;

        public FilesController(ImporterContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("importModule")]
        public async Task<IActionResult> importModule(CancellationToken cancellationToken)
        {
            
            var file = HttpContext.Request.Form.Files[0];

            if (file == null || file.Length <= 0)
            {
                return new JsonResult("File is empty");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return new JsonResult("Not Support file extension");
            }

            var module = new Module();
            var code = "";
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    var sheet1 = package.Workbook.Worksheets[0];
                    var tab1ColumnCount = sheet1.Dimension.Columns;

                    var sheet2 = package.Workbook.Worksheets[1];
                    var sheet2rowCount = sheet2.Dimension.Rows;

                    code = sheet1.Cells[2, 2].Value != null && sheet1.Cells[3, 2].Value != null ? sheet1.Cells[2, 2].Value.ToString().Trim() + sheet1.Cells[3, 2].Value.ToString().Trim() : "";
                   
                    module.ModuleNumber = sheet1.Cells[2, 2].Value != null ? int.Parse(sheet1.Cells[2, 2].Value.ToString().Trim()) : 0;
                    module.Code = code;

                    for (int row = 2; row <= sheet2rowCount; row++)
                    {
                        try
                        {
                            module.Questions.Add(new Question
                            {
                                Code=code,
                                Module = sheet2.Cells[row, 1].Value != null ? sheet2.Cells[row, 1].Value.ToString().Trim() : "",
                                Type = sheet2.Cells[row, 2].Value != null ? sheet2.Cells[row, 2].Value.ToString().Trim() : "",
                                Type2 = sheet2.Cells[row, 3].Value != null ? sheet2.Cells[row, 3].Value.ToString().Trim() : "",
                                Section = sheet2.Cells[row, 4].Value != null ? sheet2.Cells[row, 4].Value.ToString().Trim() : "",
                                Qnum = sheet2.Cells[row, 5].Value != null ? sheet2.Cells[row, 5].Value.ToString().Trim() : "",
                                Content = sheet2.Cells[row, 6].Value != null ? sheet2.Cells[row, 6].Value.ToString().Trim() : "",
                                Response01 = sheet2.Cells[row, 8].Value != null ? int.Parse(sheet2.Cells[row, 7].Value.ToString().Trim()) : 0,
                                Response02 = sheet2.Cells[row, 8].Value != null ? int.Parse(sheet2.Cells[row, 8].Value.ToString().Trim()) : 0,
                                Response03 = sheet2.Cells[row, 9].Value != null ? int.Parse(sheet2.Cells[row, 9].Value.ToString().Trim()) : 0,
                                Response04 = sheet2.Cells[row, 10].Value != null ? int.Parse(sheet2.Cells[row, 10].Value.ToString().Trim()) : 0,
                                CorrectAnswer = sheet2.Cells[row, 11].Value != null ? int.Parse(sheet2.Cells[row, 11].Value.ToString().Trim()) : 0,
                            });
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }

                    try
                    {
                        module.Settings.Add(new Settings
                        {
                            Code=code,
                            ModuleNumber = sheet1.Cells[2, 2].Value != null ? int.Parse(sheet1.Cells[2, 2].Value.ToString().Trim()) : 0,
                            Language = sheet1.Cells[3, 2].Value != null ? sheet1.Cells[3, 2].Value.ToString().Trim() : "",
                            Type = sheet1.Cells[4, 2].Value != null ? sheet1.Cells[4, 2].Value.ToString().Trim() : "",
                            Timer = sheet1.Cells[5, 2].Value != null ? int.Parse(sheet1.Cells[5, 2].Value.ToString().Trim()) : 9999,
                            CountdownTimer = sheet1.Cells[6, 2].Value != null ? sheet1.Cells[6, 2].Value.ToString().Trim() : "",
                            FinishAfterCorrectInRow = sheet1.Cells[7, 2].Value != null ? sheet1.Cells[7, 2].Value.ToString().Trim() : "",
                            FinishAfterIncorrectInRow = sheet1.Cells[8, 2].Value != null ? sheet1.Cells[8, 2].Value.ToString().Trim() : "",
                            FinishAfterCorrectTotal = sheet1.Cells[9, 2].Value != null ? sheet1.Cells[9, 2].Value.ToString().Trim() : "",
                            FinishAfterIncorrectTotal = sheet1.Cells[10, 2].Value != null ? sheet1.Cells[10, 2].Value.ToString().Trim() : "",
                            MarkAsProbablyGuessAfterXIncorrectAnswersInRow = sheet1.Cells[11, 2].Value != null ? sheet1.Cells[11, 2].Value.ToString().Trim() : "",
                            MarkAsProbablyGuessAfterXIncorrectAnswersAditional = sheet1.Cells[12, 2].Value != null ? sheet1.Cells[12, 2].Value.ToString().Trim() : "",
                            MarkAsProbablyGuessAfterXIncorrectAnswersMultiplication = sheet1.Cells[2, 2].Value != null ? sheet1.Cells[13, 2].Value.ToString().Trim() : "",
                            Calculator = sheet1.Cells[14, 2].Value != null ? sheet1.Cells[14, 2].Value.ToString().Trim() : "",
                            ReportSummary = sheet1.Cells[15, 2].Value != null ? sheet1.Cells[15, 2].Value.ToString().Trim() : "",
                            ReportSections = sheet1.Cells[16, 2].Value != null ? sheet1.Cells[16, 2].Value.ToString().Trim() : "",
                            ReportFull = sheet1.Cells[17, 2].Value != null ? sheet1.Cells[17, 2].Value.ToString().Trim() : "",
                        });
                    }
                    catch (Exception e)
                    {
                        //save bug to log or to appInsight
                        throw;
                    }

                   

                    var sheet3 = package.Workbook.Worksheets[2];
                    var sheet3rowCount = sheet3.Dimension.Rows;

                    for (int row = 2; row <= sheet3rowCount; row++)
                    {
                        try
                        {
                            module.AdditionStdScores.Add(new AdditionStdScore
                            {
                                Code=code,
                                Module = sheet3.Cells[row, 1].Value != null ? sheet3.Cells[row, 1].Value.ToString().Trim() : "",
                                Section = sheet3.Cells[row, 2].Value != null ? sheet3.Cells[row, 2].Value.ToString().Trim() : "",
                                Score = sheet3.Cells[row, 3].Value != null ? int.Parse(sheet3.Cells[row, 3].Value.ToString().Trim()) : 0,
                                StdS06 = sheet3.Cells[row, 4].Value != null ? int.Parse(sheet3.Cells[row, 4].Value.ToString().Trim()) : 0,
                                StdS07 = sheet3.Cells[row, 5].Value != null ? int.Parse(sheet3.Cells[row, 5].Value.ToString().Trim()) : 0,
                                StdS08 = sheet3.Cells[row, 6].Value != null ? int.Parse(sheet3.Cells[row, 6].Value.ToString().Trim()) : 0,
                                StdS09 = sheet3.Cells[row, 7].Value != null ? int.Parse(sheet3.Cells[row, 7].Value.ToString().Trim()) : 0,
                                StdS10 = sheet3.Cells[row, 8].Value != null ? int.Parse(sheet3.Cells[row, 8].Value.ToString().Trim()) : 0,
                                StdS11 = sheet3.Cells[row, 9].Value != null ? int.Parse(sheet3.Cells[row, 9].Value.ToString().Trim()) : 0,
                                StdS12 = sheet3.Cells[row, 10].Value != null ? int.Parse(sheet3.Cells[row, 10].Value.ToString().Trim()) : 0,
                                StdS13 = sheet3.Cells[row, 11].Value != null ? int.Parse(sheet3.Cells[row, 11].Value.ToString().Trim()) : 0,
                                StdS14 = sheet3.Cells[row, 12].Value != null ? int.Parse(sheet3.Cells[row, 12].Value.ToString().Trim()) : 0,
                                StdS15 = sheet3.Cells[row, 13].Value != null ? int.Parse(sheet3.Cells[row, 13].Value.ToString().Trim()) : 0,
                                StdS16 = sheet3.Cells[row, 14].Value != null ? int.Parse(sheet3.Cells[row, 14].Value.ToString().Trim()) : 0,
                                StdS17 = sheet3.Cells[row, 15].Value != null ? int.Parse(sheet3.Cells[row, 15].Value.ToString().Trim()) : 0,
                                StdS18 = sheet3.Cells[row, 16].Value != null ? int.Parse(sheet3.Cells[row, 16].Value.ToString().Trim()) : 0,
                                StdS19 = sheet3.Cells[row, 17].Value != null ? int.Parse(sheet3.Cells[row, 17].Value.ToString().Trim()) : 0,
                                StdS20 = sheet3.Cells[row, 18].Value != null ? int.Parse(sheet3.Cells[row, 18].Value.ToString().Trim()) : 0,

                            });
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }

                    var sheet4 = package.Workbook.Worksheets[3];
                    var sheet4rowCount = sheet4.Dimension.Rows;

                    for (int row = 2; row <= sheet4rowCount; row++)
                    {
                        try
                        {
                            module.MultiplicationStdScores.Add(new MultiplicationStdScores
                            {
                                Code=code,
                                Module = sheet4.Cells[row, 1].Value != null ? sheet4.Cells[row, 1].Value.ToString().Trim() : "",
                                Section = sheet4.Cells[row, 2].Value != null ? sheet4.Cells[row, 2].Value.ToString().Trim() : "",
                                Score = sheet4.Cells[row, 3].Value != null ? int.Parse(sheet4.Cells[row, 3].Value.ToString().Trim()) : 0,
                                StdS06 = sheet4.Cells[row, 4].Value != null ? int.Parse(sheet4.Cells[row, 4].Value.ToString().Trim()) : 0,
                                StdS07 = sheet4.Cells[row, 5].Value != null ? int.Parse(sheet4.Cells[row, 5].Value.ToString().Trim()) : 0,
                                StdS08 = sheet4.Cells[row, 6].Value != null ? int.Parse(sheet4.Cells[row, 6].Value.ToString().Trim()) : 0,
                                StdS09 = sheet4.Cells[row, 7].Value != null ? int.Parse(sheet4.Cells[row, 7].Value.ToString().Trim()) : 0,
                                StdS10 = sheet4.Cells[row, 8].Value != null ? int.Parse(sheet4.Cells[row, 8].Value.ToString().Trim()) : 0,
                                StdS11 = sheet4.Cells[row, 9].Value != null ? int.Parse(sheet4.Cells[row, 9].Value.ToString().Trim()) : 0,
                                StdS12 = sheet4.Cells[row, 10].Value != null ? int.Parse(sheet4.Cells[row, 10].Value.ToString().Trim()) : 0,
                                StdS13 = sheet4.Cells[row, 11].Value != null ? int.Parse(sheet4.Cells[row, 11].Value.ToString().Trim()) : 0,
                                StdS14 = sheet4.Cells[row, 12].Value != null ? int.Parse(sheet4.Cells[row, 12].Value.ToString().Trim()) : 0,
                                StdS15 = sheet4.Cells[row, 13].Value != null ? int.Parse(sheet4.Cells[row, 13].Value.ToString().Trim()) : 0,
                                StdS16 = sheet4.Cells[row, 14].Value != null ? int.Parse(sheet4.Cells[row, 14].Value.ToString().Trim()) : 0,
                                StdS17 = sheet4.Cells[row, 15].Value != null ? int.Parse(sheet4.Cells[row, 15].Value.ToString().Trim()) : 0,
                                StdS18 = sheet4.Cells[row, 16].Value != null ? int.Parse(sheet4.Cells[row, 16].Value.ToString().Trim()) : 0,
                                StdS19 = sheet4.Cells[row, 17].Value != null ? int.Parse(sheet4.Cells[row, 17].Value.ToString().Trim()) : 0,
                                StdS20 = sheet4.Cells[row, 18].Value != null ? int.Parse(sheet4.Cells[row, 18].Value.ToString().Trim()) : 0,

                            });
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }

                    var sheet5 = package.Workbook.Worksheets[4];
                    var sheet5rowCount = sheet5.Dimension.Rows;

                    for (int row = 2; row <= sheet5rowCount; row++)
                    {
                        try
                        {
                            module.ModuleErrorLookups.Add(new ModuleErrorLookup
                            {
                                Code=code,
                                Module = sheet5.Cells[row, 1].Value != null ? sheet5.Cells[row, 1].Value.ToString().Trim() : "",
                                Section = sheet5.Cells[row, 2].Value != null ? sheet5.Cells[row, 2].Value.ToString().Trim() : "",
                                Qnum = sheet5.Cells[row, 3].Value != null ? sheet5.Cells[row, 3].Value.ToString().Trim() : "",
                                Target = sheet5.Cells[row, 4].Value != null ? sheet5.Cells[row, 4].Value.ToString().Trim() : "",
                                Actual = sheet5.Cells[row, 5].Value != null ? sheet5.Cells[row, 5].Value.ToString().Trim() : "",
                                Category = sheet5.Cells[row, 6].Value != null ? sheet5.Cells[row, 6].Value.ToString().Trim() : "",
                                Comment = sheet5.Cells[row, 7].Value != null ? sheet5.Cells[row, 7].Value.ToString().Trim() : "",
                            });
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                    var sheet6 = package.Workbook.Worksheets[5];
                    var sheet6rowCount = sheet6.Dimension.Rows;

                    for (int row = 2; row <= sheet6rowCount; row++)
                    {
                        try
                        {
                            module.ModuleLookups.Add(new ModuleLookup
                            {
                                
                                Code=code,
                                StandardScore = sheet6.Cells[row, 1].Value != null ? int.Parse(sheet6.Cells[row, 1].Value.ToString().Trim()) : 0,
                                Band = sheet6.Cells[row, 2].Value != null ? int.Parse(sheet6.Cells[row, 2].Value.ToString().Trim()) : 0,
                                Summary = sheet6.Cells[row, 3].Value != null ? sheet6.Cells[row, 3].Value.ToString().Trim() : "",
                                SkillLevel= sheet6.Cells[row, 4].Value != null ? sheet6.Cells[row, 4].Value.ToString().Trim() : "",
                            });;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                }

                var moduleExist = context.modules.Where(x => x.Code == code).FirstOrDefault();
                

                if (moduleExist != null)
                {

                    context.modules.Remove(moduleExist);
                    context.modules.Add(module);
                    context.SaveChanges();

                    
                }
                else
                {
                    await context.AddAsync(module);
                    context.SaveChanges();
                }

                return Json(true); // można zwrocic true
            }
        }
    }
}