import React, { useState, useEffect } from "react";
import {
  FaEnvelope,
  FaPhone,
  FaMapMarkerAlt,
  FaGithub,
  FaLinkedin,
} from "react-icons/fa";

export default function Contact() {
  // 1. Form and UI states
  const [formData, setFormData] = useState({
    email: "",
    subject: "",
    message: "",
  });
  const [loading, setLoading] = useState(false);
  const [status, setStatus] = useState({ type: "", text: "" });

// Add this useEffect hook to handle the timer
useEffect(() => {
  if (status.text) {
    // Set a timer to clear the status after 5000 milliseconds (5 seconds)
    const timer = setTimeout(() => {
      setStatus({ type: "", text: "" });
    }, 5000);

    // Clean up the timer if the component unmounts or status changes before 5s
    return () => clearTimeout(timer);
  }
}, [status.text]); // This triggers whenever status.text changes

  // 2. Handle generic input updates
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  // 3. Handle asynchronous form submission to .NET backend
  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setStatus({ type: "", text: "" });

    try {
      // Replace with your actual .NET port (e.g., https://localhost:7123)
      const response = await fetch("https://my-portfolio-web-service.onrender.com/mail-management/email-sender", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: formData.email, // Maps to your EmailRequest target property
          subject: formData.subject,
          message: formData.message,
        }),
      });

      const responseText = await response.json();

      if (response.ok) {
        setStatus({ type: "success", text: "Email sent successfully!" });
        setFormData({ email: "", subject: "", message: "" }); // Reset form fields
      } else {
        setStatus({ type: "error", text: responseText.details || "Failed to send email." });
      }
    } catch (error) {
      setStatus({ type: "error", text: "Could not connect to the backend server." });
    } finally {
      setLoading(false);
    }
  };

  return (
    <section id="contact" className="bg-gray-100 py-20 px-6">
      <div className="max-w-6xl mx-auto">
        {/* Heading */}
        <div className="text-center mb-14">
          <h2 className="text-4xl font-bold text-gray-800">Contact Me</h2>
          <p className="text-gray-600 mt-3">
            Feel free to reach out if you'd like to work together or have any questions.
          </p>
        </div>

        <div className="grid md:grid-cols-2 gap-12">
          {/* Contact Information */}
          <div className="flex flex-col justify-between">
            <div>
              <h3 className="text-2xl font-semibold text-gray-800 mb-6">Get In Touch</h3>

              <div className="space-y-5">
                <div className="flex items-center gap-4">
                  <FaEnvelope className="text-blue-600 text-xl" />
                  <div>
                    <p className="font-medium">Email</p>
                    <p className="text-gray-600">synancy0926@gmail.com</p>
                  </div>
                </div>

                <div className="flex items-center gap-4">
                  <FaPhone className="text-blue-600 text-xl" />
                  <div>
                    <p className="font-medium">Phone</p>
                    <p className="text-gray-600">+63 928 599 2665</p>
                  </div>
                </div>

                <div className="flex items-center gap-4">
                  <FaMapMarkerAlt className="text-blue-600 text-xl" />
                  <div>
                    <p className="font-medium">Location</p>
                    <p className="text-gray-600">Philippines</p>
                  </div>
                </div>
              </div>
            </div>
          </div>

          {/* Contact Form */}
          <form onSubmit={handleSubmit} className="bg-white p-8 rounded-xl shadow-lg">
            <div className="mb-5">
              <label htmlFor="email" className="block mb-2 font-medium">
                Email
              </label>
              <input
                id="email"
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                placeholder="Enter your email"
                required
                className="w-full border rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>

            <div className="mb-5">
              <label htmlFor="subject" className="block mb-2 font-medium">
                Subject
              </label>
              <input
                id="subject"
                type="text"
                name="subject"
                value={formData.subject}
                onChange={handleChange}
                placeholder="Enter your subject"
                required
                className="w-full border rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>

            <div className="mb-5">
              <label htmlFor="message" className="block mb-2 font-medium">
                Message
              </label>
              <textarea
                id="message"
                name="message"
                value={formData.message}
                onChange={handleChange}
                rows="5"
                placeholder="Write your message..."
                required
                className="w-full border rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
              ></textarea>
            </div>

            {/* Status Notifications */}
            {status.text && (
              <div
                className={`mb-5 p-3 rounded-lg text-sm font-medium ${
                  status.type === "success"
                    ? "bg-green-100 text-green-800"
                    : "bg-red-100 text-red-800"
                }`}
              >
                {status.text}
              </div>
            )}

            <button
              type="submit"
              disabled={loading}
              className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold hover:bg-blue-700 transition disabled:bg-blue-400 disabled:cursor-not-allowed"
            >
              {loading ? "Sending..." : "Send Message"}
            </button>
          </form>
        </div>
      </div>
    </section>
  );
}