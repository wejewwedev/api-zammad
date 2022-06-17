using System.Text.Json.Serialization;

namespace ZammadAPI.Data.ZammadModels
{
    public class User
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("organization_id")]
        public int OrganizationId { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("image")]
        public object Image { get; set; }

        [JsonPropertyName("image_source")]
        public object ImageSource { get; set; }

        [JsonPropertyName("web")]
        public string Web { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("mobile")]
        public string Mobile { get; set; }

        [JsonPropertyName("department")]
        public object Department { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("address")]
        public object Address { get; set; }

        [JsonPropertyName("vip")]
        public bool Vip { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("last_login")]
        public object LastLogin { get; set; }

        [JsonPropertyName("source")]
        public object Source { get; set; }

        [JsonPropertyName("login_failed")]
        public int LoginFailed { get; set; }

        [JsonPropertyName("out_of_office")]
        public bool OutOfOffice { get; set; }

        [JsonPropertyName("out_of_office_start_at")]
        public object OutOfOfficeStartAt { get; set; }

        [JsonPropertyName("out_of_office_end_at")]
        public object OutOfOfficeEndAt { get; set; }

        [JsonPropertyName("out_of_office_replacement_id")]
        public object OutOfOfficeReplacementId { get; set; }

        [JsonPropertyName("preferences")]
        public Preferences Preferences { get; set; }

        [JsonPropertyName("updated_by_id")]
        public int UpdatedById { get; set; }

        [JsonPropertyName("created_by_id")]
        public int CreatedById { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("role_ids")]
        public List<int> RoleIds { get; set; }

        [JsonPropertyName("organization_ids")]
        public List<object> OrganizationIds { get; set; }

        [JsonPropertyName("authorization_ids")]
        public List<object> AuthorizationIds { get; set; }

        [JsonPropertyName("karma_user_ids")]
        public List<object> KarmaUserIds { get; set; }

        [JsonPropertyName("group_ids")]
        public GroupIds GroupIds { get; set; }
    }
}
