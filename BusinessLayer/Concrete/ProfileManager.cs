using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProfileManager:IProfileService
	{
		IProfileDal _profileDal;

		public ProfileManager(IProfileDal profileDal)
		{
			_profileDal = profileDal;
		}

		public List<Profile> GetList()
		{
			return _profileDal.List();
		}
	}
}
