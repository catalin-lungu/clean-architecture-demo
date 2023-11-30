import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Students = () => {
    const [students, setStudents] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const populateStudentData = async () => {
            try {
                const apiUrl = "https://localhost:7003" //process.env.REACT_APP_API_BASE_URL;
                const response = await fetch(`${apiUrl}/api/Students`);
                const data = await response.json();
                setStudents(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching students:', error);
            }
        };

        populateStudentData();
    }, []);

    const renderStudentsTable = (students) => (
        <table className='table table-striped my-4' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th scope="col">Student ID</th>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col">Email</th>
                    <th scope="col">Check Ins</th>
                </tr>
            </thead>
            <tbody>
                {students.map(student =>
                    <tr key={student.id}>
                        <td scope="row">{student.id}</td>
                        <td>{student.firstName}</td>
                        <td>{student.lastName}</td>
                        <td>{student.email}</td>
                        <td>
                            <Link to={`/${student.id}/check-in`}>View Check Ins</Link>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    const contents = loading ? <p>Loading...</p> : renderStudentsTable(students);

    return (
        <div className="row">
            <div className="col-12">
                <h1 id="tabelLabel">Students</h1>
                {contents}
                <Link to="/add-student" className="btn btn-primary">Add Student</Link>
            </div>
        </div>
    );
};

export default Students;