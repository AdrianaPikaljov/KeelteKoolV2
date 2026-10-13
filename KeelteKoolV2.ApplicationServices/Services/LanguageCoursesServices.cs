using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using KeelteKoolV2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeelteKoolV2.ApplicationServices.Services
{
    public class LanguageCoursesServices : ILanguageCoursesServices
    {
        private readonly KeelteKoolV2Context _context;

        public LanguageCoursesServices(KeelteKoolV2Context context)
        {
            _context = context;
        }

        public async Task<LanguageCourse> Create(LanguageCourseDTO dto)
        {
            return null;
        }
        public async Task<LanguageCourse> Update(LanguageCourseDTO dto)
        {
            return null;
        }
        public async Task<LanguageCourse> Update(Guid id)
        {
            return null;
        }
        public async Task<LanguageCourse> Delete(Guid id)
        {
            return null;
        }
    }
}
