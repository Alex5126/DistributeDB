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
            var labelQuery = new Label(3, 2, "Query: ");
            var query = new TextField(14, 2, 40, "");
            var consult = new Button(60, 2, "Ok");
            top.Add(labelQuery, query, consult);
            Application.Run();
        }
	}
}
