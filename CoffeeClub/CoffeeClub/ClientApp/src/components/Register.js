import React, { useState } from 'react';

const Register = props => {

    const [firstName, setFirstName] = useState("");
    const [secondName, setSecondName] = useState("");
    const [interests, setInterests] = useState("");
    const [region, setRegion] = useState("");
    const [country, setCountry] = useState("");
    const [city, setCity] = useState("");
    const [role, setRole] = useState("");
    const [department, setDepartment] = useState("");
    const [organization, setOrganization] = useState("");
    const [age, setAge] = useState("");
    const [sex, setSex] = useState("");

    const createPerson = () => {
        return {
            'id': 0,
            'firstName': firstName,
            'secondName': secondName,
            'interests': (interests.split(',')),
            'region': region,
            'country': country,
            'city': city,
            'role': role,
            'department': department,
            'organization': organization,
            'age': +age,
            'sex': sex
        };
    }

    const generateNewPersonForm = () =>
    <form onSubmit={tryRunQuery}>
            <div>
                <label htmlFor="firstName">First name: </label>
                <input type="text" id="firstName" onChange={firstNameChangedHandler} />
            </div>
            <div>
                <label htmlFor="secondName">Second name: </label>
                <input type="text" id="secondName" onChange={secondNameChangedHandler} />
            </div>
            <div>
                <label htmlFor="interests">Interests (comma separated): </label>
                <input type="text" id="interests" onChange={interestChangedHandler} />
            </div>
            <div>
                <label htmlFor="region">Region: </label>
                <input type="text" id="region" onChange={regionChangedHandler} />
            </div>
            <div>
                <label htmlFor="country">Country: </label>
                <input type="text" id="country" onChange={countryChangedHandler} />
            </div>
            <div>
                <label htmlFor="city">City: </label>
                <input type="text" id="city" onChange={cityChangedHandler} />
            </div>
            <div>
                <label htmlFor="role">Role: </label>
                <input type="text" id="role" onChange={roleChangedHandler} />
            </div>
            <div>
                <label htmlFor="department">Department: </label>
                <input type="text" id="department" onChange={departmentChangedHandler} />
            </div>
            <div>
                <label htmlFor="organization">Organization: </label>
                <input type="text" id="organization" onChange={organizationChangedHandler} />
            </div>
            <div>
                <label htmlFor="age">Age: </label>
                <input type="text" id="age" onChange={ageChangedHandler} />
            </div>
            <div>
                <label htmlFor="sex">Sex: </label>
                <input type="text" id="Sex" onChange={sexChangedHandler} />
            </div>
            <input type="submit" className="btn btn-primary" value="Run query" />
            <input type="reset" className="btn btn-primary" value="Reset form" />
    </form>

    const checkFormCompleted = () => {
        if (firstName.length === 0 || secondName.length === 0 || interests.length === 0 || region.length === 0 || country.length === 0 || city.length === 0 || role.length === 0 || department.length === 0 || organization.length === 0 || age.length === 0 || sex.length === 0) {
            alert('You should insert all fields.')
            return false;
        }
        if (isNaN(age) || !Number.isInteger(+age)) {
            alert('Age must be an integer');
            return false;
        }
        if (!(sex === "M" || sex === "F")) {
            alert('Sex must be either "M" or "F"');
            return false;
        }
        return true;
    }

    const tryRunQuery = async event => {
        event.preventDefault();
        if (checkFormCompleted())
            await sendDataToCreateNewPerson();
    }

    const firstNameChangedHandler = (event) => {
        setFirstName(event.target.value);
    }

    const secondNameChangedHandler = (event) => {
        setSecondName(event.target.value);
    }

    const interestChangedHandler = (event) => {
        setInterests(event.target.value);
    }

    const regionChangedHandler = (event) => {
        setRegion(event.target.value);
    }

    const countryChangedHandler = (event) => {
        setCountry(event.target.value);
    }

    const cityChangedHandler = (event) => {
        setCity(event.target.value);
    }

    const roleChangedHandler = (event) => {
        setRole(event.target.value);
    }

    const departmentChangedHandler = (event) => {
        setDepartment(event.target.value);
    }

    const organizationChangedHandler = (event) => {
        setOrganization(event.target.value);
    }

    const ageChangedHandler = (event) => {
        setAge(event.target.value);
    }

    const sexChangedHandler = (event) => {
        setSex(event.target.value);
    }

    const sendDataToCreateNewPerson = async () => {
        console.log('calling add user');
        fetch('/api/users/add', {
                'method': 'POST',
                body: JSON.stringify(createPerson())
                                })
            .then(response => response.json())
            .then(() => alert("Person added!"))
            .catch(error => alert(error));
    }

    return (
      <div>
        <h1 id="tabelLabel" >Register new user</h1>
        <p>Please enter all the information of the person you want to register.</p>
        {generateNewPersonForm()}
      </div>
    );
}

export default Register;