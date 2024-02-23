using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Author
	{
		public int Id { get; set; }
		public string Fullname { get; set; }
		public DateOnly Birthdate { get; set; }
		public Gender Gender { get; set; } = Gender.Male;
		public ICollection<Book> Books { get; set; }
	}
}
