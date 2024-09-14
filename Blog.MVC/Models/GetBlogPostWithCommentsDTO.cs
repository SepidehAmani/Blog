namespace Blog.MVC.Models
{
    public class GetBlogPostWithCommentsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<GetCommentDTO>? Comments { get; set; }
    }


}
