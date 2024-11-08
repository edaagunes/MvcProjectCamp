using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContentManager : IContentService
	{
		IContentDal _contentDal;

		public ContentManager(IContentDal contentDal)
		{
			_contentDal = contentDal;
		}

		public void ContentAdd(Content content)
		{
			_contentDal.Insert(content);
		}

		public void ContentDelete(Content content)
		{
			throw new NotImplementedException();
		}

		public void ContentUpdate(Content content)
		{
			throw new NotImplementedException();
		}

		public Content GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, int> GetContentCountByHeading()
		{
			// Başlık ID'sine göre içerikleri gruplama ve her başlığın içerik sayısını alma
			var contentCounts = _contentDal.List()
				.GroupBy(c => c.Heading.HeadingName) // Başlık ismine göre gruplama
				.ToDictionary(g => g.Key, g => g.Count()); // Başlık adı ve içerik sayısını alıyoruz

			return contentCounts;
		}

		public List<Content> GetList(string p)
		{
			return _contentDal.List(x=>x.ContentValue.Contains(p));
		}

		public List<Content> GetList()
		{
			return _contentDal.List();
		}

		public List<Content> GetListByHeadingId(int id)
		{
			return _contentDal.List(x=>x.HeadingId==id);
		}

		public List<Content> GetListByWriter(int id)
		{
			return _contentDal.List(x => x.WriterId == id);
		}
	}
}
