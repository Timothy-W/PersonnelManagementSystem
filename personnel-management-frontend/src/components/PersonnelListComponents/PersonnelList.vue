<template>
  <PersonnelListHeader
    @toggle-add-person="toggleAddPerson"
    :showAddPerson="showAddPerson"
  />
  <!-- @add-personnel="$emit('add-personnel', newPerson)" does not work. Why?-->
  <AddPersonnelForm v-show="showAddPerson" @add-person="emiteAddPerson" />

  <div :key="currentPerson.id" v-for="currentPerson in personList">
    <Person
      :person="currentPerson"
      @delete-person="$emit('delete-person', currentPerson.id)"
      @update-person="emiteUpdatePerson"
    />
  </div>
</template>

<script>
import PersonnelListHeader from "./PersonnelListHeader.vue";
import Person from "./Person.vue";
import AddPersonnelForm from "./AddPersonnelForm.vue";

export default {
  name: "PersonnelList",
  props: {
    personList: Array,
  },
  data() {
    return {
      showAddPerson: false,
    };
  },
  components: {
    Person,
    PersonnelListHeader,
    AddPersonnelForm,
  },
  emits: ["add-person", "delete-person", "update-person"],
  methods: {
    toggleAddPerson() {
      this.showAddPerson = !this.showAddPerson;
    },
    emiteAddPerson(newPerson) {
      this.toggleAddPerson();
      this.$emit("add-person", newPerson);
    },
    emiteUpdatePerson(person) {
      //console.log("PersonnelList "+ JSON.stringify(person)) //good
      this.$emit("update-person", person);
    },
  },
};
</script>

