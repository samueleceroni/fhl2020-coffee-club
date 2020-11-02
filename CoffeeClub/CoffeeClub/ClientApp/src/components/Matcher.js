import React, { Component } from 'react';

export class Matcher extends Component {
    static displayName = Matcher.name;

    constructor(props) {
        super(props);
        this.state = { people: [], loading: true };
    }

    componentDidMount() {
        this.populateMatchesData();
    }

    static renderMatchesTable(people) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Age</th>
                        <th>Sex</th>
                        <th>Role</th>
                    </tr>
                </thead>
                <tbody>
                    {people.map(forecast =>
                        <tr key={people.id}>
                            <td>{people.firstname}</td>
                            <td>{people.secondname}</td>
                            <td>{people.age}</td>
                            <td>{people.sex}</td>
                            <td>{people.role}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Matcher.renderMatchesTable(this.state.people);

        return (
            <div>
                <h1 id="tabelLabel" >Matching people</h1>
                <p>Searching for potential matches.</p>
                {contents}
            </div>
        );
    }

    async populateMatchesData() {
        const response = await fetch('match');
        console.log(response);
        const data = await response.json();
        this.setState({ people: data, loading: false });
    }
}
