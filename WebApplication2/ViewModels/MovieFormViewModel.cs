using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
	public class MovieFormViewModel
	{
		public Movie Movie { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
	}
}