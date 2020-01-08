using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdaptITRegistrationApp.modules;
using AdaptITRegistrationApp.controllers;

namespace AdaptITRegistrationApp.secure
{

    public partial class ExcelExport : System.Web.UI.Page
    {
        conRegistration reg = new conRegistration();

        protected void ExportType(Int64 CompanyID, Int64 PresentationID, string TableName)
        {
            reg.Registrations_PerPresentation_SelectAll(gvExportList, CompanyID, PresentationID, TableName);
            
        }

        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvExportList.AllowPaging = false;

                //ExportType();

                gvExportList.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvExportList.HeaderRow.Cells)
                {
                    cell.BackColor = gvExportList.HeaderStyle.BackColor;
                    cell.HorizontalAlign = gvExportList.HeaderStyle.HorizontalAlign;
                }
                foreach (GridViewRow row in gvExportList.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvExportList.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvExportList.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvExportList.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { } </style>";
               // Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            ExportType(Sessionhandler.CompanyID, Sessionhandler.PresentationID, Sessionhandler.TableName);
            ExportToExcel();
            
        }

       
        protected void gvExportList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Sessionhandler.TableName == System.Configuration.ConfigurationManager.AppSettings["ExternalTableName"].ToString())
            {
                e.Row.Cells[0].Visible = false; // ER.ExtReg_ID,'
                e.Row.Cells[1].Visible = true; //ER.Firstname
                e.Row.Cells[2].Visible = true; //ER.Lastname
                e.Row.Cells[3].Visible = true; //ER.Company
                e.Row.Cells[4].Visible = true; //ER.Email
                e.Row.Cells[5].Visible = true; //ER.Designation
                e.Row.Cells[6].Visible = true; //ER.ContactNumber
                e.Row.Cells[7].Visible = true; //EmailSent
                e.Row.Cells[8].Visible = false; //EmailRegistrationSubject
                e.Row.Cells[9].Visible = false; //EmailTemplateDirectory
                e.Row.Cells[10].Visible = false; //EmailTemplateName                            
            }
        }
    }
}