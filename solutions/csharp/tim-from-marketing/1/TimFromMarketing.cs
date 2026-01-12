static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string formattedDepartment = department == null ? "OWNER" : department.ToUpper();
        string formattedId = id == null ? "" : "[" + id + "] - ";
        return formattedId + name + " - " + formattedDepartment;
    }
}
