using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.Repositories
{
    public interface ISubjectRepository
    {
        Subject Add(Subject subject, IEnumerable<string> faculties);
        Subject Update(Subject subject);
        Subject Delete(int id);
        Subject GetSubject(int id);
        IEnumerable<Subject> GetAllSubjects();

        IEnumerable<FacultySubject> GetAllSubjectRequests();
        void requestSubjectAccess(int SId, string FId);

        void acceptRequest(int sid, string fid);
        void rejectRequest(int sid, string fid);

        IEnumerable<FacultySubject> GetFacultySubjectsOfFaculty(string id);

    }
}
