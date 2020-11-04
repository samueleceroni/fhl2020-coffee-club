import React, { Component } from 'react';

export class Matcher extends Component {
    static displayName = Matcher.name;

    constructor(props) {
        super(props);
        console.log("The id used is " + String(this.props.match.params.id));
        this.id = this.props.match.params.id;
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
                    {people.map(person =>
                        <tr key={person.id}>
                            <td>{person.firstName}</td>
                            <td>{person.secondName}</td>
                            <td>{person.age}</td>
                            <td>{person.sex}</td>
                            <td>{person.role}</td>
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
                <p>Displaying the list of potential matches.</p>
                {contents}
            </div>
        );
    }

    async populateMatchesData() {
        var response = null;
        if (this.id == null)
        {
            response = await fetch('match');
        }
        else
        {
            response = await fetch('match/' + String(this.id));
        }
        const data = await response.json();
        console.log(data);
        this.setState({ people: data, loading: false });
    }
}
