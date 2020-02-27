using AutoMapper;
using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.BLL.Infrastructure;
using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Services
{
    public class PollService : IPollService
    {
        IUnitOfWork Database { get; set; }
        static Random random = new Random();
        IMapper mapperPoll = new MapperConfiguration(cfg => cfg.CreateMap<Poll, PollDTO>()).CreateMapper();
        IMapper mapperAnswer = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
        
        public PollService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddPoll(PollDTO pollDTO)
        {
            if (pollDTO.Title == null)
            {
                throw new ValidationException("Poll name is empty", "");
            }
            if (pollDTO.Answers == null)
            {
                throw new ValidationException("Answers not found", "");
            }
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerDTO>()).CreateMapper();
            //var answers = mapper.Map<ICollection<AnswerDTO>, ICollection<Answer>>(pollDTO.Answers);
            List<Answer> answers = new List<Answer>();
            foreach (var answer in pollDTO.Answers)
            {
                Answer tempAnswer = new Answer() { Amount = answer.Amount, Text = answer.Text, PollId = answer.PollId };
                answers.Add(tempAnswer);
            }
            Poll poll = new Poll { Title = pollDTO.Title, Answers = answers };
            Database.Polls.Create(poll);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public PollDTO FindPoll(int? id)
        {
            if (id == null)
                throw new ValidationException("Poll id not set", "");
            var poll = Database.Polls.Find(id.Value);
            if (poll == null)
                throw new ValidationException("Poll not found", "");
            //var answers = mapperPoll.Map<IEnumerable<Answer>, List<AnswerDTO>>(Database.Answers.FindByPoll(id));
            List<Answer> answers = Database.Answers.FindByPoll(id).ToList();
            //List<AnswerDTO> answersDTO = new List<AnswerDTO>();
            //foreach (var answer in answers)
            //{
            //    AnswerDTO tempAnswer = new AnswerDTO() { Amount = answer.Amount, Text = answer.Text, PollId = answer.PollId };
            //    answersDTO.Add(tempAnswer);
            //}
            return new PollDTO { Title = poll.Title, Answers = answers, PollId = poll.PollId };
        }
        public PollDTO GetRandomPoll()
        {
            int count = Database.Polls.GetRecordsNumber();
            int id = random.Next(1, count);
            var poll = Database.Polls.Find(id);
            // var answers = mapperAnswer.Map<IEnumerable<Answer>, List<AnswerDTO>>(Database.Answers.FindByPoll(id));
            var answers = Database.Answers.FindByPoll(id).ToList();
            return new PollDTO { Title = poll.Title, Answers = answers, PollId = poll.PollId };

        }

        public IEnumerable<PollDTO> FindPolls()
        {
            var res = Database.Polls.FindAll();
            List<PollDTO> polls = new List<PollDTO>();
            foreach (var poll in res)
            {
                PollDTO pollDTO = new PollDTO() { PollId = poll.PollId, Title = poll.Title, Answers = poll.Answers.ToList()};
                //List<AnswerDTO> answers = new List<AnswerDTO>();
                //foreach (var answer in poll.Answers)
                //{
                //    AnswerDTO answerDTO = new AnswerDTO() { AnswerId = answer.AnswerId, Amount = answer.Amount, Text = answer.Text, PollId = answer.PollId };
                //    answers.Add(answerDTO);
                //}
                //pollDTO.Answers = answers;
                polls.Add(pollDTO);
            }

            return polls;
        }

       

        public IEnumerable<AnswerDTO> FindPollAnswers(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable<Answer>, IEnumerable<AnswerDTO>>()).CreateMapper();
            return mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(Database.Answers.FindByPoll(id));
        }

        public void UpdateAnswer(Answer answer)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, Answer>()).CreateMapper();
            //var answer = mapper.Map<AnswerDTO, Answer>(answerDTO);
            
            //Answer answer = new Answer() {AnswerId=answer.AnswerId, Amount = answer.Amount, PollId = answerDTO.PollId, Text = answerDTO.Text };

            Database.Answers.Update(answer);
            
        }

        public void Save()
        {
            Database.Save();
        }
    }
}
