using StudentPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.RepoImplementation
{
    public class NoticeRepository : INoticeRepository
    {
        private readonly AppDbContext context;
        public NoticeRepository(AppDbContext _context)
        {
            context = _context;
        }
        public Notice Add(Notice notice)
        {
            context.Notices.Add(notice);
            context.SaveChanges();
            return notice;
        }

        public Notice Delete(int id)
        {
            var notice = context.Notices.Find(id);
            if (notice != null)
            {
                context.Notices.Remove(notice);
                context.SaveChanges();
            }
            return notice;
        }

        public IEnumerable<Notice> GetAllNotices()
        {
            return context.Notices;
        }

        public Notice GetNotice(int id)
        {
            return context.Notices.Find(id);
        }

        public Notice Update(Notice noticeModified)
        {
            var notice = context.Notices.Attach(noticeModified);
            notice.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return noticeModified;
        }
    }
}
