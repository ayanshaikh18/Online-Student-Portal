using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.Repositories
{
    public interface INoticeRepository
    {
        Notice Add(Notice notice);
        Notice Update(Notice notice);
        Notice Delete(int id);
        Notice GetNotice(int id);
        IEnumerable<Notice> GetAllNotices();
    }
}
