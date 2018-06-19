using ConsoleTables;
using DistributedDB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace DistributedDB
{
	class Program
	{
		static void Main(string[] args)
		{
            Application.Init();
            var top = Application.Top;
            var win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "Distribuited DB App");
            top.Add(win);
            var labelQuery = new Label(3, 3, "Query: ");
            var query = new TextField(14, 3, 40, "");
            var consult = new Button(60, 3, "Ok");
            var textView = new TextView(new Rect(3, 7, 115, 70))
            {
                Text = string.Empty,
                
            };            

            var tableText = string.Empty;

            consult.Clicked = () =>
            {
                var queryWritten = query.Text.ToString();
                using (DBService db = new DBService())
                {
					tableText = string.Empty;

					switch (queryWritten.ToLower())
                    {
                        case "select * from clientes":
                            var list = db.GetCiudades();
                            var table = new ConsoleTable();
                            for (int i = 0; i < list?[0].Table.Columns.Count; i++)
                            {
                                table.Columns.Add(list[0].Table.Columns[i].ColumnName);
                            }
                            foreach (var item in list)
                            {
                                var values = new string[item.ItemArray.Length];
                                for (int i = 0; i < item.ItemArray.Length; i++)
                                {
                                    values[i] = item.ItemArray[i].ToString();
                                }
                                table.AddRow(values);

                            }
                            tableText = table.ToString();
                            break;
						case "select * from ciudades":
							var listCity = db.GetCiudades();
							var tableCity = new ConsoleTable();
							for (int i = 0; i < listCity?[0].Table.Columns.Count; i++)
							{
								tableCity.Columns.Add(listCity[0].Table.Columns[i].ColumnName);
							}
							foreach (var item in listCity)
							{
								var values = new string[item.ItemArray.Length];
								for (int i = 0; i < item.ItemArray.Length; i++)
								{
									values[i] = item.ItemArray[i].ToString();
								}
								tableCity.AddRow(values);

							}
							tableText = tableCity.ToString();
							break;
						case "select * from paises":
							var listCountry = db.GetCiudades();
							var tableCountry = new ConsoleTable();
							for (int i = 0; i < listCountry?[0].Table.Columns.Count; i++)
							{
								tableCountry.Columns.Add(listCountry[0].Table.Columns[i].ColumnName);
							}
							foreach (var item in listCountry)
							{
								var values = new string[item.ItemArray.Length];
								for (int i = 0; i < item.ItemArray.Length; i++)
								{
									values[i] = item.ItemArray[i].ToString();
								}
								tableCountry.AddRow(values);

							}
							tableText = tableCountry.ToString();
							break;
						case "select * from destinos":
							var listDes = db.GetDestino();
							var tableDes = new ConsoleTable();
							for (int i = 0; i < listDes?[0].Table.Columns.Count; i++)
							{
								tableDes.Columns.Add(listDes[0].Table.Columns[i].ColumnName);
							}
							foreach (var item in listDes)
							{
								var values = new string[item.ItemArray.Length];
								for (int i = 0; i < item.ItemArray.Length; i++)
								{
									values[i] = item.ItemArray[i].ToString();
								}
								tableDes.AddRow(values);

							}
							tableText = tableDes.ToString();
							break;
						default:
                            break;
                    }
                }
                textView.Text = tableText;
            };
            
            win.Add(labelQuery, query, consult, textView);
            Application.Run();
        }
	}
}
