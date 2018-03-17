import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TodoItem } from '../../models/todo.item';

@Component({
  selector: 'app-todo',
  templateUrl: 'todo.component.html',
  styleUrls: ['todo.component.css']
})
export class TodoComponent implements OnInit {

  constructor() { }

  todos: TodoItem[] = [
    {
      title: 'bir',
      createdAt: new Date(),
      complete: true,
      completedAt: new Date()
    },
    {
      title: 'iki',
      createdAt: new Date(),
      complete: false
    },
    {
      title: 'iki',
      createdAt: new Date(),
      complete: false
    }
  ];

  ngOnInit() {
  }

  addTodo(title: HTMLInputElement) {
    this.todos.push({
      title: title.value,
      complete: false,
      createdAt: new Date()
    });

    title.value = '';
    title.focus();
  }

}
