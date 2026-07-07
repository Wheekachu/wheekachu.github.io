import { FaGithub, FaLinkedin } from "react-icons/fa";

export default function Navbar() {
  return (
    <header className="fixed top-0 left-0 w-full bg-slate-900/80 backdrop-blur-md border-b border-slate-800 z-50">
      <nav className="max-w-7xl mx-auto flex items-center justify-between px-6 py-4">
        {/* Logo */}
        <a
          href="#home"
          className="text-2xl font-bold text-white tracking-wide"
        >
          Nancy<span className="text-blue-500">.</span>
        </a>

        {/* Navigation */}
        <ul className="hidden md:flex items-center gap-8 text-gray-300 font-medium">
          <li>
            <a href="#me" className="hover:text-blue-500 transition">
              Home
            </a>
          </li>

          <li>
            <a href="#about" className="hover:text-blue-500 transition">
              About
            </a>
          </li>

          <li>
            <a href="#skills" className="hover:text-blue-500 transition">
              Skills
            </a>
          </li>

          <li>
            <a href="#projects" className="hover:text-blue-500 transition">
              Projects
            </a>
          </li>

          <li>
            <a href="#contact" className="hover:text-blue-500 transition">
              Contact
            </a>
          </li>
        </ul>

        {/* Social Icons */}
        <div className="flex items-center gap-4">
          <a
            href="https://github.com/wheekachu"
            target="_blank"
            rel="noopener noreferrer"
            className="text-gray-300 hover:text-white text-xl transition"
          >
            <FaGithub />
          </a>

          <a
            href="https://www.linkedin.com/in/nancy-ross-sy-9114a9240"
            target="_blank"
            rel="noopener noreferrer"
            className="text-gray-300 hover:text-blue-500 text-xl transition"
          >
            <FaLinkedin />
          </a>
        </div>
      </nav>
    </header>
  );
}