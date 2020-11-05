import React, { useState, useEffect } from 'react';

const RecurrentMatch = () => {
    const [groups, setGroups] = useState([]);

    useEffect(() => {
        const fetchGroups = async () => {
            const response = await fetch('api/recurrentmatch');
            const groups = await response.json();

            setGroups(groups);
        }

        fetchGroups();
    });

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>First Person</th>
                    <th>Second Person</th>
                </tr>
            </thead>
            <tbody>
                {groups.map((group, index) => <Group key={index} groupMembers={group.groupMembers} name={index + 1} />)}
            </tbody>
        </table>
    );
}

const Group = ({ groupMembers, name }) => {
    return (
        <tr>
            {groupMembers.map((member, index) => <td key={index}>{member.firstName} {member.secondName}</td>)}
        </tr>
    );
}

export default RecurrentMatch;