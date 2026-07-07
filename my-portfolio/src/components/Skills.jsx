const skills = [
  ".NET Core",
  "ASP.NET",
  "VB.NET",
  "C#",
  "React JS",
  "Angular",
  "Tailwind CSS",
  "SQL Server Profiler",
  "SAP Crystal Reports",
  "Debugging",
  "Unit Testing",
  "SQL Server",
  "Entity Framework",
  "Git",
  "REST API",
];

export default function Skills() {
  return (
    <section id="skills" className="py-20 bg-gray-100">
      <div className="max-w-6xl mx-auto">

        <h2 className="text-4xl font-bold text-center mb-10">
          Skills
        </h2>

        <div className="grid md:grid-cols-5 gap-4">
          {skills.map(skill => (
            <div
              key={skill}
              className="bg-white rounded-lg shadow p-5 text-center font-semibold"
            >
              {skill}
            </div>
          ))}
        </div>

      </div>
    </section>
  );
}