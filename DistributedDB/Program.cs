using ConsoleTables;
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
                Text = "Esta es una prueba",
                
            };

            var table = new ConsoleTable("one", "two", "three");
            table.AddRow(1, 2, 3)
                 .AddRow("this line should be longer", "yes it is", "oh");

            var tableText = table.ToString();

            textView.Text = tableText;
            win.Add(labelQuery, query, consult, textView);
            Application.Run();
        }
	}
}
