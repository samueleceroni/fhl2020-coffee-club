import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, MS world!</h1>
            <p>Ever felt like... you want to know other people? or you have ideas to develop and you're looking for a partner? or simply want to chat with someone who has completely different interests than you?  <i>MS Coffee Club is what you're looking for then!</i></p>
        <p>MS Coffee Club is an internal MS tool which allows employees to get to know each other semi-randomly, to support diversity and inclusion while trying to meet your preferences at the same time.</p>
        <p>Some of the aim of the club:</p>
        <ul>
            <li>expand your network in the world wide One Microsoft</li>
            <li>exchange ideas, thoughts, tips about how to live your best life in Microsoft</li>
            <li>know more parts of the company and understand each other points of view</li>
            <li>foster the exchange of ideas which may lead to the creation of new projects</li>
            <li>have a coffee altogether!</li>
        </ul>
        <h3>How to participate?</h3>
        <p>Just sign up for the club in the web app, decide the frequency of your regular meetings and select your preferences so that we can find a good matches for you :)</p>
        <p>Should you feel you want to have another coffee club chat out of your scheduled ones, you can use the on-the-spot meeting button! You will either get a match instantly or wait for it in a queue :)</p>
      </div>
    );
  }
}
