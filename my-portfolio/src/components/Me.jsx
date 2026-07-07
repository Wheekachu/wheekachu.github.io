import profile from "../assets/nancy.jpg"; // Replace with your image

export default function Me() {
  return (
    <section id="me" className="min-h-screen bg-slate-900 text-white flex items-center">
      <div className="max-w-7xl mx-auto px-6 grid md:grid-cols-2 gap-12 items-center">
        {/* Left Side */}
        <div>
          <p className="text-blue-400 text-lg mb-2">Hello, I'm</p>

          <h1 className="text-5xl md:text-6xl font-bold">
            Nancy Ross Sy
          </h1>

          <h2 className="text-2xl md:text-3xl text-gray-300 mt-4">
            Full Stack .NET Developer
          </h2>

          <p className="text-gray-400 mt-6 leading-8 max-w-lg">
            Passionate about building scalable web applications using
            .NET, React, SQL Server, and modern web technologies.
            I enjoy solving real-world problems through clean and
            maintainable code.
          </p>

          <div className="mt-8 flex gap-4">
            <button className="bg-blue-600 hover:bg-blue-700 px-6 py-3 rounded-lg">
              View Projects
            </button>

            <a
            href="https://drive.google.com/file/d/1m2bkJmB2KvFJbpK5zj2IxZGIisjEZw8U/view?usp=sharing"
            target="_blank"
            rel="noopener noreferrer"
            className="border border-white px-6 py-3 rounded-lg hover:bg-white hover:text-black transition">
              Download CV</a>
          </div>
        </div>

        {/* Right Side */}
        <div className="flex justify-center">
          <img
            src={profile}
            alt="Nancy Ross Sy"
            className="w-80 md:w-96 rounded-full border-4 border-blue-500 shadow-2xl"
          />
        </div>
      </div>
    </section>
  );
}