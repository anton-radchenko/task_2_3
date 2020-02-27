using Blog.BLL.DTO;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.BLL.Abstract
{
    public interface IPollService
    {
        void AddPoll(PollDTO articleDTO);

        PollDTO FindPoll(int? id);
        PollDTO GetRandomPoll();
        IEnumerable<PollDTO> FindPolls();

        IEnumerable<AnswerDTO> FindPollAnswers( int? id);
        void UpdateAnswer(Answer answer);

        void Dispose();
        void Save();
    }
}
